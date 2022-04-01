using System.Collections;
using Modules.Movements;
using Objects.SpaceObjects;
using UnityEngine;

namespace Objects.Turrets
{
    public abstract class Turret : MonoBehaviour
    {
        [SerializeField] private protected float _attackDelay;

        [SerializeField] private Movement _movement;

        private bool _isAttacking;


        protected abstract void AttackTarget(SpaceObject target);
        public abstract float GetDps();


        public void SetTarget(SpaceObject target)
        {
            _movement.HardRotateToTarget(transform, target.transform);
            StartCoroutine(AttackCoroutine(target));
        }


        private IEnumerator AttackCoroutine(SpaceObject target)
        {
            if (_isAttacking) yield break;
            _isAttacking = true;
            AttackTarget(target);
            yield return new WaitForSeconds(_attackDelay);
            _isAttacking = false;
        }
    }
}