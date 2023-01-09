using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusLine : MonoBehaviour
{
    Stats playerStats;
    float prevHealth;
    Text txt;
    // Start is called before the first frame update
    void Start()
    {
        playerStats = GameObject.Find("Player").GetComponent<Stats>();
        this.txt = this.GetComponent<Text>();
        this.txt.text = "Health: " + playerStats.Health;
    }

    // Update is called once per frame
    void Update()
    {
        int Health = playerStats.Health;
        if (this.prevHealth != Health)
        {
            this.txt.text = "Health: " + Health;
        }
        this.prevHealth = Health;
    }
}
