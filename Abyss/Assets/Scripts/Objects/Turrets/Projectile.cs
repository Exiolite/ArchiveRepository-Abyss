using System.Collections;
using Modules.Movements;
using Objects.SpaceObjects;
using Objects.SpaceObjects.Dynamic;
using UnityEngine;

namespace Objects.Turrets
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private float _damage;
        [SerializeField] private Movement _movement;

        public float Damage => _damage;

        private SpaceObject _target;


        public void SetTarget(SpaceObject target) => _target = target;


        private void Start()
        {
            StartCoroutine(Destroy());
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (_target == null) return;
            if (other.gameObject == _target.gameObject)
            {
                var dynamicTarget = (Ship) _target;
                dynamicTarget.ApplyDamage(_damage);
                Destroy(gameObject);
            }
        }

        private void Update()
        {
            _movement.HardMoveForward(transform);
        }

        private IEnumerator Destroy()
        {
            yield return new WaitForSeconds(5);
            Destroy(gameObject);
        }
    }
}