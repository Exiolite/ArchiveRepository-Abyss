using UnityEngine;

namespace Utilities
{
    public class ParticlesPlayer
    {
        public void Play(ParticleSystem target)
        {
            target.transform.localPosition = new Vector3(Random.Range(-1.5f,1.5f),Random.Range(-1.5f,1.5f), 0);
            target.Play();
        }
    }
}