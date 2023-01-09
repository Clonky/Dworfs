using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCircle : MonoBehaviour
{
    public float TimeToSpawn;
    public GameObject EnemyToSpawn;
    float toggleTime = 0.5f;
    float toggleTimer;
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        toggleTimer = toggleTime;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        TimeToSpawn -= Time.deltaTime;
        toggleTimer -= Time.deltaTime;
        Blink();
        Spawn();
    }

    void Spawn()
    {
        if (TimeToSpawn <= 0)
        {
            Instantiate(EnemyToSpawn, transform.position, transform.rotation);
            Destroy(gameObject);
        }

    }

    void Blink()
    {
        if (toggleTimer <= 0)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;
            toggleTimer = toggleTime;
        } 

    }
}
