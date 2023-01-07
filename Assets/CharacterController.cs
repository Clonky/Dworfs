using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    float HorizontalInput;
    float VerticalInput;
    Rigidbody2D rb;
    public float SpeedMultiplier;
    Animator animator;
    // Start is called before the first frame update
    private void Start()
    {
        this.animator = gameObject.GetComponent<Animator>();
        this.rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        this.VerticalInput = Input.GetAxis("Vertical");
        this.HorizontalInput = Input.GetAxis("Horizontal");
        if (WantsToMove()) { 
            animator.SetBool("isWalking", true);
        } else
        {
            animator.SetBool("isWalking", false);
        }
    }
    void FixedUpdate()
    {
        if (WantsToMove())
        {
            this.gameObject.transform.Translate((this.VerticalInput * Vector3.up + this.HorizontalInput * Vector3.right).normalized * Time.fixedDeltaTime * this.SpeedMultiplier);
        } else
        {
            this.rb.velocity = Vector3.zero;
        }
    }

    bool WantsToMove()
    {
        return this.VerticalInput != 0 || this.HorizontalInput != 0;
    }
}
