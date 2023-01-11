using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusLineHealth : StatusLine<int>
{
    protected override int GetStat()
    {
        return playerStats.Health;
    }
}
