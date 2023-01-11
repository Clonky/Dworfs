using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusLineXP : StatusLine<int>
{
    protected override int GetStat()
    {
        return playerStats.XP;
    }
}
