using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float cooldown;
    public GameObject projectilePrefab;
    Timer timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = new Timer(cooldown);
    }

    // Update is called once per frame
    void Update()
    {
        timer.Elapsed += Time.deltaTime;
        if (timer.IsFinished())
        {
            SpawnProjectile();
            this.timer = new Timer(cooldown);
        }
    }

    private void FixedUpdate()
    {
    }

    void SpawnProjectile()
    {
        Instantiate(projectilePrefab, this.transform.position, this.transform.rotation);
    }

    struct Timer
    {
        public Timer(double duration)
        {
            this.Duration = duration;
            this.Elapsed = 0;
        }

        public double Elapsed { get; set; }
        public double Duration { get; set; }

        public bool IsFinished()
        {
            if (this.Elapsed > this.Duration) { return true; } else { return false; }
        }
    }
}
