using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Tools
{
    public struct Timer
    {
        public Timer(float dur)
        {
            this.Duration = dur;
            this.Elapsed = 0f;
        }

        public float Duration { get; }
        public float Elapsed { get; set; }

        public bool IsFinished()
        {
            if (Elapsed > Duration)
            {
                return true;
            } else
            {
                return false;
            }
        }

        public void Reset()
        {
            this.Elapsed = 0f;
        }
    }
}