using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : BehaviourMovement
{
    Vector2 InputStorage;
    Animator animator;
    // Start is called before the first frame update
    protected override void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        Stats = GetComponent<Stats>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected override void Update()
    {
        FaceInMovementDirection();
    }

    void FaceInMovementDirection()
    {
        if (rb.velocity.x < 0)
        {
            spriteRenderer.flipX = true;
        } else
        {
            spriteRenderer.flipX = false;
        }
    }

    public override void execute()
    {
        InputStorage = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (InputStorage.magnitude > 0)
        {
            animator.SetBool("isWalking", true);
            rb.velocity += InputStorage * Stats.Accel * Time.fixedDeltaTime;
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, Stats.Speed);
        } else
        {
            animator.SetBool("isWalking", false);
            rb.velocity = Vector2.zero;
        }
    }
}
