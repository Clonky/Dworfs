using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Tools;

public class DyingBehaviour : MonoBehaviour
{
    public AudioClip DyingSound;
    public Timer TimeToDie;
    SpriteRenderer spriteRenderer;
    public GameObject xpOrbPrefab;
    // Start is called before the first frame update
    void Start()
    {
        TimeToDie = new Timer(1.0f);
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.red;
        ShutdownInteraction();
        AudioSource.PlayClipAtPoint(DyingSound, transform.position, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        TimeToDie.Elapsed += Time.deltaTime;
        FadeAway();
        if (TimeToDie.IsFinished())
        {
            Instantiate(xpOrbPrefab, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }
    }

    void ShutdownInteraction()
    {
        BehaviourMovement behaviourMovement = GetComponent<BehaviourMovement>();
        behaviourMovement.Stop();
        behaviourMovement.enabled = false;
        GetComponent<Rigidbody2D>().simulated = false;
    }

    void FadeAway()
    {
        Color currColor = spriteRenderer.color;
        currColor.a = 1 - (TimeToDie.Elapsed / TimeToDie.Duration);
        spriteRenderer.color = currColor;
    }
}
