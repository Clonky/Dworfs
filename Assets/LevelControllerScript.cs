using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelControllerScript : MonoBehaviour
{
    GameObject player;
    Transform playerTransform;
    Timer spawnTimer;
    public float spawnRange;
    public double spawnInterval;
    public List<GameObject> enemyPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("Player");
        this.spawnTimer = new Timer(this.spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        this.playerTransform = this.player.transform;
        this.spawnTimer.Elapsed += Time.deltaTime;
        if (this.spawnTimer.IsFinished()) {
            spawn();
            this.spawnTimer = new Timer(spawnInterval);
        }
    }

    void spawn()
    {
        GameObject toSpawn = this.enemyPrefabs[Random.Range(0, this.enemyPrefabs.Count)];
        GameObject currEnemy = Instantiate(toSpawn);
        currEnemy.transform.position = PickPositionAroundPlayer();
    }

    Vector3 PickPositionAroundPlayer()
    {
        Vector3 basePos = this.player.transform.position;
        float angle = Random.Range(0, 360);
        Vector3 pos = basePos + (new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * spawnRange);
        return pos;
    }

    struct Timer
    {
        public Timer(double duration)
        {
            Elapsed = 0.0;
            Duration = duration;
        }

        public double Elapsed { get;  set; }
        public double Duration { get; }

        public bool IsFinished()
        {
            if (this.Elapsed >= this.Duration)
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
}
