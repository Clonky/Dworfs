using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage;
    public float speed;
    public float lifetime;
    public GameObject Target;
    Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 targetPos = Vector3.zero;
        if (Target == null)
        {
            targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        } else
        {
            targetPos = Target.transform.position;
        }
        dir = targetPos - transform.position;
        dir = dir.normalized;
        dir.z = 0;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
        TimeoutProjectile();
    }

    void FixedUpdate()
    {
    }

    void TimeoutProjectile()
    {
        this.lifetime -= Time.deltaTime;
        if (this.lifetime <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy) {
            enemy.TakeDamage(this.damage);
            Destroy(this.gameObject);
        }
    }
}
