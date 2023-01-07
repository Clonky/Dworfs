using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusLine : MonoBehaviour
{
    GameObject PlayerObj;
    float prevHealth;
    Text txt;
    // Start is called before the first frame update
    void Start()
    {
        this.PlayerObj = GameObject.Find("Player");
        this.txt = this.GetComponent<Text>();
        this.txt.text = "Health: " + this.PlayerObj.GetComponent<Player>().Health;
    }

    // Update is called once per frame
    void Update()
    {
        float Health = this.PlayerObj.GetComponent<Player>().Health;
        if (this.prevHealth != Health)
        {
            this.txt.text = "Health: " + Health;
        }
        this.prevHealth = Health;
    }
}
