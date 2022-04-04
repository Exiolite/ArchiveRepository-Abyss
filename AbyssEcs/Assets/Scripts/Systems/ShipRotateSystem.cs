using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    public struct ShipRotateSystem : IEcsRunSystem
    {
        private EcsFilter<ShipRotateComponent, TargetingComponent, TransformComponent> _filter;


        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var shipRotateComponent = ref _filter.Get1(i);
                ref var targetComponent = ref _filter.Get2(i);
                ref var transformComponent = ref _filter.Get3(i);

                if (targetComponent.Transform)
                {
                    var directionToTarget = targetComponent.Transform.position - transformComponent.Transform.position;
                    var angleToTarget = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg;
                    var targetRotation = Quaternion.Euler(0,0, angleToTarget);
                    transformComponent.Transform.rotation = Quaternion.Lerp(transformComponent.Transform.rotation, targetRotation, Time.deltaTime * shipRotateComponent.RotateSpeed / 10);
                }
            }
        }
    }
}