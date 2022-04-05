using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    public class MovementSmoothRunSystem : IEcsRunSystem
    {
        private EcsFilter<MovementSmoothComponent, TransformTargetComponent, TransformCurrentComponent> _filter;
        
        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var movementComponent = ref _filter.Get1(i);
                
                ref var targetingComponent = ref _filter.Get2(i);
                ref var targetTransform = ref targetingComponent.Transform;
                
                ref var transformComponent = ref _filter.Get3(i);
                ref var transform = ref transformComponent.Transform;
                

                ref var speed = ref movementComponent.CurrentSpeed;

                if (targetTransform)
                {
                    speed = Mathf.Clamp((speed + (movementComponent.Velocity * Time.deltaTime)), 0, movementComponent.MaxSpeed);
                }
                else
                {
                    speed = Mathf.Clamp(speed - (speed * Time.deltaTime), 0, movementComponent.MaxSpeed);
                }
                transform.Translate(transform.right * (speed / 50), Space.World);
            }
        }
    }
}