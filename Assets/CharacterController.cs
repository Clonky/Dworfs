using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    Stats stats;
    BehaviourMovement movement;
    // Start is called before the first frame update
    private void Start()
    {
        movement = GetComponent<BehaviourMovement>();
        stats = GetComponent<Stats>();
    }

    private void Update()
    {
    }
    void FixedUpdate()
    {
        movement.execute();
    }

}
