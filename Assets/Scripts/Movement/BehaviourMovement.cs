using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BehaviourMovement : MonoBehaviour
{
    protected GameObject Target;
    protected Stats Stats;
    protected Rigidbody2D rb;

    protected virtual void Start()
    {
        Target = GameObject.Find("Player");
        Stats = GetComponent<Stats>();
        rb = GetComponent<Rigidbody2D>();
    }

    public abstract void execute();
}

