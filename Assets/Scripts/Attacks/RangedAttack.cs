using System.Collections;
using UnityEngine;

public class RangedAttack : AttackBehaviour
{
    public float AttackRange;
    public override void execute()
    {
        Instantiate(Projectile, gameObject.transform.position, gameObject.transform.rotation);
    }

    public override bool CanAttack()
    {
        if ((gameObject.transform.position - Target.transform.position).magnitude <= AttackRange)
        {
            return true;
        } else
        {
            return false;
        }
    }
}