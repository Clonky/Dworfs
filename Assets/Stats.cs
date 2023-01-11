using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public float Speed;
    public float Accel;
    public float PreferredRangeToTarget;
    public int Health;
    public int lvl;
    public int XP;

    public void GainXP(int amountXP)
    {
        XP += amountXP;
    }
}
