using System.Collections;
using UnityEngine;

public class Chasing : BehaviourMovement
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