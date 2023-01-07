using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class Enemy : MonoBehaviour
{
    public int Health;
    public float Speed;
    public float Accel;
    GameObject Target;
    Vector2 diretionToTarget;
    Rigidbody2D rb;
    DamageTextHandler dmgTextHandler;
    // Start is called before the first frame update
    void Start()
    {
        dmgTextHandler = GameObject.Find("DamageTextEventHandler").GetComponent<DamageTextHandler>();
        this.Target = GameObject.Find("Player");
        this.rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        this.diretionToTarget = (Target.transform.position - this.transform.position).normalized;
    }

    void FixedUpdate()
    {
        this.rb.velocity += this.diretionToTarget * Accel * Time.fixedDeltaTime;
        this.rb.velocity = Vector2.ClampMagnitude(this.rb.velocity, this.Speed);
    }

    public void TakeDamage(int damage) {
        DmgTxtEvent dmgEvent = new DmgTxtEvent(damage, transform.position);
        dmgTextHandler.pushEventOnStack(dmgEvent);
        this.Health -= damage;
        if (this.Health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
