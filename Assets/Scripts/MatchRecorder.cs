using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchRecorder : MonoBehaviour
{
    public int earned;
    public int bestEarned;
    public int money;
    public int pumpkinsSmashed;
    public int totalPumpkinsSmashed;
    public int velocity;
    public int bestVelocity;
    public int meters;
    public int bestMeters;

    void Start()
    {
        GameManager.instance.matchRecorder = this;
    }

}
