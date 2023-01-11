using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPOrbApproach : MonoBehaviour
{
    public float distanceToActivate = 0.1f;
    public float maxSpeed = 1.2f;
    public int amountXP = 1;
    public AudioClip gainXPSound;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if ((player.transform.position - gameObject.transform.position).magnitude < distanceToActivate)
        {
            float speed = maxSpeed * Time.fixedDeltaTime;
            Vector3 dir = (player.transform.position - gameObject.transform.position).normalized;
            gameObject.transform.position += speed * dir;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            AudioSource.PlayClipAtPoint(gainXPSound, gameObject.transform.position);
            collision.gameObject.GetComponent<Stats>().GainXP(amountXP);
            Destroy(gameObject);
        }
    }
}
