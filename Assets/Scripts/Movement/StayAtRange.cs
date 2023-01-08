using System.Collections;
using UnityEngine;


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
