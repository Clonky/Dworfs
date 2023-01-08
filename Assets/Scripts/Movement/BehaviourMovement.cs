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

public class Chasing: BehaviourMovement
{
    public override void execute()
    {
        WalkTowards(GetDirectionToTarget(Target));
    }
    protected void WalkTowards(Vector2 directionToTarget)
    {
        rb.velocity += directionToTarget * Stats.Accel * Time.fixedDeltaTime;
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, Stats.Speed);
    }

    protected Vector2 GetDirectionToTarget(GameObject Target)
    {
        Vector2 directionToTarget = (Target.transform.position - transform.position).normalized;
        return directionToTarget;
    }
}

public class StayAtRange: Chasing
{
    public override void execute()
    {
        if (GetRangeToTarget(Target) > Stats.PreferredRangeToTarget)
        {
            WalkTowards(GetDirectionToTarget(Target));
        } else if (Mathf.Abs(GetRangeToTarget(Target) - Stats.PreferredRangeToTarget) < 0.1) {
            rb.velocity = Vector3.zero;
        } else
        {
            WalkTowards(-GetDirectionToTarget(Target));
        }
    }

    float GetRangeToTarget(GameObject Target)
    {
        return (Target.transform.position - gameObject.transform.position).magnitude;
    }

}
