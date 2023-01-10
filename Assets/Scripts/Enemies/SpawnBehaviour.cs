using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Tools;

public abstract class SpawnBehaviour : MonoBehaviour
{
    public float spawnInterval;
    public float spawnRadius;
    public List<GameObject> monsters;
    public GameObject SpawnCirclePrefab;
    GameObject player;
    Timer spawnTimer;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        spawnTimer = new Timer(spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer.Elapsed += Time.deltaTime;
        if (spawnTimer.IsFinished())
        {
            SpawnEnemies();
            spawnTimer.Reset();
        }
    }

    public abstract void SpawnEnemies();
    
    protected GameObject CreateSpawnCircle(GameObject imonster, Vector3 pos)
    {
        GameObject spawnCircle = Instantiate(SpawnCirclePrefab);
        SpawnCircle spawnProps = spawnCircle.GetComponent<SpawnCircle>();
        spawnProps.EnemyToSpawn = imonster;
        spawnProps.TimeToSpawn = spawnInterval;
        spawnCircle.transform.position = pos;
        return spawnCircle;
    }

    protected Vector2 GetPointAroundPlayer()
    {
        Vector3 basePos = player.transform.position;
        float angle = Random.Range(0, 360);
        Vector3 pos = basePos + (new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * spawnRadius);
        return pos;
    }
}
