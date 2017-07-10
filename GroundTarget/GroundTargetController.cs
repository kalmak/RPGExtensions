using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTargetController : MonoBehaviour {
    public LayerMask groundLayer;
    public static GroundTargetController Instance { get; set; }
    public bool isGroundTargeting = false;
    public GameObject GroundTargetPrefab;
    public GameObject GroundTargetObjectPrefab;
    Ray ray;
    float xOffset;
    float zOffset;

    // Use this for initialization
    void Start () {
        if (Instance != null && Instance != this)
            Destroy(this.gameObject);
        else
            Instance = this;
    }
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKeyDown(KeyCode.T))
        {
            isGroundTargeting = !isGroundTargeting;
            if(isGroundTargeting)
            {
                ShowGroundTarget("PracticeTarget");
            }
            else
            {
                if (GroundTargetPrefab != null)
                    Destroy(GroundTargetPrefab);
            }
            
        }

        if(isGroundTargeting)
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity,groundLayer))
            {
                Vector3 target = new Vector3(hit.point.x + xOffset, hit.point.y + .5f, hit.point.z+zOffset);
                GroundTargetPrefab.transform.position = target;
            }
        }
       
		
	}

    public void ShowGroundTarget(string slug)
    {
        GroundTargetPrefab = (GameObject)Instantiate(Resources.Load<GameObject>("GroundTarget/Graphics/" + slug));
        Bounds bounds = GroundTargetPrefab.GetComponent<MeshFilter>().mesh.bounds;
        xOffset = bounds.size.x / 2;
        zOffset = bounds.size.z / 2; 
    }

    public void ActivateGroundTarget(string slug)
    {
        GroundTargetObjectPrefab = (GameObject)Instantiate(Resources.Load<GameObject>("GroundTarget/Objects/" + slug),GroundTargetPrefab.transform.position, GroundTargetPrefab.transform.rotation);
        isGroundTargeting = false;
        Destroy(GroundTargetPrefab);
    }
}
