using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class Enemy : MonoBehaviour
{
    Stats Stats;
    StayAtRange stayAtRange;
    DamageTextHandler dmgTextHandler;
    // Start is called before the first frame update
    void Start()
    {
        dmgTextHandler = GameObject.Find("DamageTextEventHandler").GetComponent<DamageTextHandler>();
        Stats = GetComponent<Stats>();
        stayAtRange = gameObject.AddComponent<StayAtRange>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
        stayAtRange.execute();
    }


    public void TakeDamage(int damage) {
        DmgTxtEvent dmgEvent = new DmgTxtEvent(damage, transform.position);
        dmgTextHandler.pushEventOnStack(dmgEvent);
        this.Stats.Health -= damage;
        if (this.Stats.Health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
