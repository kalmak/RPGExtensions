using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedEffectController : MonoBehaviour {

    public List<TimedEffect> timedEffects = new List<TimedEffect>();
    CharacterStats characterStats;
    public float timer = 0;


    private void Start()
    {
        characterStats = GetComponent<PlayerController>().stats;
        timer += Time.deltaTime;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        //this is just for testing the effects
        if (Input.GetKeyDown(KeyCode.P))
        {
            TimedEffect te = new TimedEffect(new List<BaseStat>()
                {new BaseStat(BaseStatType.Strength, 10, "Strength")}, 5);
            AddEffect(te);
        }

        //keep this
        if (timedEffects.Count > 0)
            CheckEffects();

    }

    public void AddEffect(TimedEffect effect)
    {
        Debug.Log(characterStats.stats[0].CalculateStatValue());
        effect.StartTime = timer;
        timedEffects.Add(effect);
        characterStats.AddStatBonus(effect.Stats);
        Debug.Log(characterStats.stats[0].CalculateStatValue());
    }

    public void RemoveEffect(TimedEffect effect)
    {
        Debug.Log(characterStats.stats[0].CalculateStatValue());
        timedEffects.Remove(effect);
        characterStats.RemoveStatBonus(effect.Stats);
        Debug.Log(characterStats.stats[0].CalculateStatValue());
    }

    void CheckEffects()
    {
        List<TimedEffect> tempList = new List<TimedEffect>();
        foreach(TimedEffect eff in timedEffects)
        {
            if (timer >= eff.StartTime + eff.Duration)
                tempList.Add(eff);
        }

        if(tempList.Count >0)
        {
            foreach (TimedEffect eff in tempList)
                RemoveEffect(eff);
        }

    }
	
}
