using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;
using Assets.Scripts.Tools;

public class Enemy : MonoBehaviour
{
    Stats Stats;
    DamageTextHandler dmgTextHandler;
    BehaviourMovement behaviourMovement;
    // Start is called before the first frame update
    void Start()
    {
        dmgTextHandler = GameObject.Find("DamageTextEventHandler").GetComponent<DamageTextHandler>();
        Stats = GetComponent<Stats>();
        behaviourMovement = GetComponent<BehaviourMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Stats.Health <= 0)
        {
            GetComponent<DyingBehaviour>().enabled = true;
        }
    }

    void FixedUpdate()
    {
        behaviourMovement.execute();
    }


    public void TakeDamage(int damage) {
        DmgTxtEvent dmgEvent = new DmgTxtEvent(damage, transform.position);
        dmgTextHandler.pushEventOnStack(dmgEvent);
        this.Stats.Health -= damage;
    }
}
