using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackBehaviour : MonoBehaviour
{
    public float CoolDown;
    public GameObject Projectile;
    public GameObject Target;
    protected Timer timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = new Timer(CoolDown);
    }

    // Update is called once per frame
    void Update()
    {
        timer.Elapsed += Time.deltaTime;
        if (timer.isFinished() & CanAttack()) {
            execute();
            timer.Reset();
        }
    }

    public abstract void execute();

    public abstract bool CanAttack();

    protected struct Timer
    {
        public Timer(float dur)
        {
            this.Duration = dur;
            this.Elapsed = 0;
        }

        public float Elapsed { get; set; }
        public float Duration { get; }

        public bool isFinished()
        {
            if (this.Elapsed >= this.Duration)
            {
                return true;
            } else
            {
                return false;
            }
        }

        public void Reset()
        {
            this.Elapsed = 0;
        }
    }
}
