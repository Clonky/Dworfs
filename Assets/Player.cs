using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   
    Stats stats;
    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponent<Stats>();
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    public void TakeDamage(int damage)
    {
        if (stats.Health > 0)
        {
            stats.Health -= damage;
        }
        if (stats.Health < 0)
        {
            stats.Health = 0;
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>())
        {
            TakeDamage(1);
        }
    }
}
