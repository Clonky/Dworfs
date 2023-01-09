using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage;
    public float speed;
    public float lifetime;
    Vector3 dir;
    // Start is called before the first frame update
    public virtual void Start()
    {
        Vector3 targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dir = GetTargetDir(targetPos);
        RotateProjectileTowardsTarget(dir);
    }

    // Update is called once per frame
    public void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
        TimeoutProjectile();
    }

    public void FixedUpdate()
    {
    }

    public void TimeoutProjectile()
    {
        this.lifetime -= Time.deltaTime;
        if (this.lifetime <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public Vector3 GetTargetDir(Vector3 targetPos)
    {
        dir = targetPos - transform.position;
        dir = dir.normalized;
        dir.z = 0;
        return dir;
    }

    public void RotateProjectileTowardsTarget(Vector3 targetDir)
    {
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        var enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy) {
            enemy.TakeDamage(this.damage);
            Destroy(this.gameObject);
        }
    }
}
