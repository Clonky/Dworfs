using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

abstract public class StatusLine<T> : MonoBehaviour where T : System.IComparable<T>
{
    protected Stats playerStats;
    protected T prevStat;
    protected Text txt;
    public string statLabel;
    // Start is called before the first frame update
    void Start()
    {
        playerStats = GameObject.Find("Player").GetComponent<Stats>();
        Setup();
    }

    protected abstract T GetStat();

    void Setup()
    {
        txt = GetComponent<Text>();
    }

    void UpdateText()
    {
        txt.text = statLabel + ": " + GetStat();
    }

    // Update is called once per frame
    void Update()
    {
        if (isChanged())
        {
            UpdateText();
        }
        prevStat = GetStat();
    }

    bool isChanged()
    {
        T stat = GetStat();
        return !stat.Equals(prevStat);
    }
}
