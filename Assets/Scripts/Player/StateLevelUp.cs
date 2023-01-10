using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateLevelUp : MonoBehaviour
{
    Player player;
    BehaviourMovement behaviourMovement;
    Animator animator;
    public Sprite lvlUpSprite;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        behaviourMovement = GetComponent<BehaviourMovement>();
        animator = GetComponent<Animator>();
        behaviourMovement.Stop();
        behaviourMovement.enabled = false;
        animator.SetBool("lvlingUp", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
