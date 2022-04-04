using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    public class TurretRotationSystem : IEcsRunSystem
    {
        private EcsFilter<TurretsComponent, TransformTargetComponent, TransformCurrentComponent> _filter;


        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var turretsComponent = ref _filter.Get1(i);
                ref var targetingComponent = ref _filter.Get2(i);
                ref var transformComponent = ref _filter.Get3(i);
                ref var turretList = ref turretsComponent.Turrets;
                
                if (targetingComponent.Transform)
                {
                    foreach (var turret in turretList)
                    {
                        var directionToTarget = 
                            targetingComponent.Transform.position - transformComponent.Transform.position;
                    
                        var angleToTarget = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg;
                        turret.transform.rotation = Quaternion.Euler(0f, 0f, angleToTarget);
                    }
                }
            }
        }
    }
}