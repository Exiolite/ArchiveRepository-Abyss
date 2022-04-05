using Components;
using Leopotam.Ecs;
using MonoBehaviours;
using MonoBehaviours.Data;
using Tags;
using UnityEngine;

namespace Systems
{
    public class MovementOffsetRunSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world;
        
        private EcsFilter<TransformCurrentComponent, TransformTargetComponent, MovementOffsetComponent> _filter;

        
        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var transformCurrentComponent = ref _filter.Get1(i);
                ref var transformTargetComponent = ref _filter.Get2(i);
                ref var movementOffsetComponent = ref _filter.Get3(i);

                if (transformTargetComponent.Transform)
                {
                    var desiredPosition = transformTargetComponent.Transform.position + movementOffsetComponent.Offset;
                    var smoothedPosition = Vector3.Lerp(transformCurrentComponent.Transform.position, desiredPosition, movementOffsetComponent.SmoothSpeed * Time.deltaTime);
                    transformCurrentComponent.Transform.position = smoothedPosition;
                }
            }
        } }
}