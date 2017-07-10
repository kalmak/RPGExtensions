using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedEffect {
    public List<BaseStat> Stats { get; set; }
    public float Duration { get; set; }
    public float StartTime { get; set; }

    public TimedEffect(List<BaseStat> st, float dur)
    {
        Stats = st;
        Duration = dur;
    }
}
