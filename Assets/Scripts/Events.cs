using System.Collections;
using UnityEngine;
using TMPro;

namespace Assets.Scripts
{
    public struct DmgTxtEvent
    {
        public DmgTxtEvent(int damage, Vector3 position)
        {
            this.Damage = damage;
            this.Position = position;
        }
        public int Damage { get; }
        public Vector3 Position { get; }

        public void HandleEvent(ref TextMeshPro textMesh, ref ParticleSystemRenderer particleRenderer, ref ParticleSystem particleSystem)
        {
            textMesh.text = this.Damage.ToString();
            particleRenderer.mesh = textMesh.mesh;
            particleSystem.Emit(1);
        }
    }
}
