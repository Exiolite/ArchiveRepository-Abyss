using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    public class TurretRotationSystem : IEcsRunSystem
    {
        private EcsFilter<TurretsComponent, TargetingComponent> _filter;


        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var turretsComponent = ref _filter.Get1(i);
                ref var targetingComponent = ref _filter.Get2(i);
                ref var turretList = ref turretsComponent.Turrets;
                
                if (targetingComponent.TargetTransform)
                {
                    foreach (var turret in turretList)
                    {
                        var directionToTarget = 
                            targetingComponent.TargetTransform.position - targetingComponent.CurrentTransform.position;
                    
                        var angleToTarget = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg;
                        turret.transform.rotation = Quaternion.Euler(0f, 0f, angleToTarget);
                    }
                }
            }
        }
    }
}