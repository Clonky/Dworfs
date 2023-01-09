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
