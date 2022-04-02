using System.Collections;
using UnityEngine;

namespace System.Effects
{
    public class ShipExplode : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _explodeParticles;

        private void Start()
        {
            StartCoroutine(DestroyTime());
            _explodeParticles.Play();
        }

        private IEnumerator DestroyTime()
        {
            yield return new WaitForSeconds(3);
            Destroy(gameObject);
        }
    }
}