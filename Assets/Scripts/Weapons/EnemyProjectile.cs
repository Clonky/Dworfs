using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : Projectile
{
    Vector3 dir;
    // Start is called before the first frame update
    public override void Start()
    {
        Vector3 targetPos = GameObject.Find("Player").transform.position;
        dir = GetTargetDir(targetPos);
        RotateProjectileTowardsTarget(dir);
    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.gameObject.GetComponent<Player>();
        if (player) {
            player.TakeDamage(this.damage);
            Destroy(this.gameObject);
        }
    }
}
