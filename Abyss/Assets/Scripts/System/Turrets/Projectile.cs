using System.Collections;
using System.Health;
using System.Movements;
using System.SpaceObjects;
using UnityEngine;

namespace System.Turrets
{
    public class Projectile : MonoBehaviour
    {
        public Damage Damage => _damage;
        [SerializeField] private Damage _damage;

        public Movement Movement => _movement;
        [SerializeField] private Movement _movement;

        
        private SpaceObject _target;

        
        private void Start()
        {
            StartCoroutine(Destroy());
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<Ship>(out var ship))
            {
                ship.HealthStats.TryApplyDamage(_damage);
            }
        }

        private void Update()
        {
            _movement.HardMoveForward(transform);
        }

        
        public void SetTarget(SpaceObject target)
        {
            _target = target;
        }


        private IEnumerator Destroy()
        {
            yield return new WaitForSeconds(5);
            Destroy(gameObject);
        }
    }
}