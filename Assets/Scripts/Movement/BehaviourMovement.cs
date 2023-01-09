using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BehaviourMovement : MonoBehaviour
{
    protected GameObject Target;
    protected Stats Stats;
    protected Rigidbody2D rb;
    protected SpriteRenderer spriteRenderer;

    protected virtual void Start()
    {
        Target = GameObject.Find("Player");
        Stats = GetComponent<Stats>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected virtual void Update()
    {
        if (Target)
        {
            FacePlayer();
        }
    }

    public abstract void execute();

    public void Stop()
    {
        rb.velocity = Vector3.zero;
    }

    public void FacePlayer()
    {
        Vector2 vecToPlayer = gameObject.transform.position - Target.transform.position;
        if (vecToPlayer.x < 0)
        {
            spriteRenderer.flipX = true;
        } else
        {
            spriteRenderer.flipX = false;
        }
    }
}

