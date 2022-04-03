using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    public class ShipMovementSystem : IEcsRunSystem
    {
        private EcsFilter<ShipMovementComponent, TargetingComponent> _filter;
        
        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var movementComponent = ref _filter.Get1(i);
                ref var targetingComponent = ref _filter.Get2(i);
                
                ref var transform = ref movementComponent.Transform;
                ref var targetTransform = ref targetingComponent.TargetTransform;
                
                var speed = 0.0f;
                var resultSpeed = 0.0f;

                if (targetTransform)
                {
                    resultSpeed = Mathf.Clamp(speed + (movementComponent.Velocity * Time.deltaTime), 0, movementComponent.MaxSpeed);
                    var directionToTarget = targetTransform.transform.position - transform.position;
                    var angleToTarget = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg;
                    var targetRotation = Quaternion.Euler(0,0, angleToTarget);
                    transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * movementComponent.AngleSpeed / 10);
                }
                else
                {
                    resultSpeed = Mathf.Clamp(speed - movementComponent.MaxSpeed * Time.deltaTime, 0, movementComponent.MaxSpeed);
                }
                transform.Translate(transform.up * resultSpeed, Space.World);
            }
        }
    }
}