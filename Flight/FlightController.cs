using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FlightController : MonoBehaviour {

    public Transform playerMesh;
    public float flyHeight = 8;
    public bool IsFlying { get; set; }
    public float speed = 1f;
    public float rotationSpeed = 5;
    float startPosition;
    NavMeshAgent agent;
    Vector3 flyingRotation = new Vector3(90.0f, 0.0f, 0.0f);
    Vector3 normalRotation = new Vector3(0.0f, 0.0f, 0.0f);

    Vector3 flyingPosition;
    Vector3 normalPosition; 

    // Use this for initialization
    void Start () {
        startPosition = playerMesh.localPosition.y;
        IsFlying = false;
        agent = GetComponent<NavMeshAgent>();
        flyingPosition = new Vector3(0, flyHeight, 0);
        normalPosition = new Vector3(0.0f, startPosition, 0.0f);
    }
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.F))
        {
            IsFlying = !IsFlying;
        }	
	}
    private void LateUpdate()
    {
        if (IsFlying)
        {
            if (agent.remainingDistance > agent.stoppingDistance)
            {
                if (playerMesh.localRotation.x != flyingRotation.x)
                {       
                    playerMesh.localRotation = Quaternion.Lerp(playerMesh.localRotation, Quaternion.Euler(flyingRotation), rotationSpeed * Time.deltaTime);
                }

            }
            else
            {
                
                if (playerMesh.localRotation != Quaternion.Euler(Vector3.zero))
                {
                    playerMesh.localRotation = Quaternion.Lerp(playerMesh.localRotation, Quaternion.Euler(Vector3.zero), rotationSpeed * Time.deltaTime);
                }

            }
            if (playerMesh.position.y != flyHeight)
                playerMesh.localPosition = Vector3.Lerp(playerMesh.localPosition, flyingPosition, speed * Time.deltaTime);

        }
        else
        {
            if (playerMesh.position.y != startPosition)
                playerMesh.localPosition = Vector3.Lerp(playerMesh.localPosition, normalPosition, speed * Time.deltaTime);

            if (playerMesh.localRotation != Quaternion.Euler(normalRotation))

                playerMesh.localRotation = Quaternion.Lerp(Quaternion.Euler(flyingRotation), Quaternion.Euler(normalRotation), rotationSpeed * Time.time);

        }
    }
}
