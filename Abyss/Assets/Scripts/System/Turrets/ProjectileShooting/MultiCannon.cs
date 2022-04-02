using System.SpaceObjects;
using UnityEngine;

namespace System.Turrets.ProjectileShooting
{
    public class MultiCannon : Turret
    {
        //TurretAttributes
        [SerializeField] private Projectile _projectile;
        
        
        
        protected override void AttackTarget(SpaceObject target)
        {
            var projectile = Instantiate(_projectile, transform);
            projectile.SetTarget(target);
        }

        public override float GetDps() => _projectile.Damage / _attackDelay;
    }
}