using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    public class MovementLinearSystem : IEcsRunSystem
    {
        private EcsFilter<MovementLinearComponent, TransformCurrentComponent> _filter;


        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var movementLinearComponent = ref _filter.Get1(i);
                ref var transformCurrentComponent = ref _filter.Get2(i);
                ref var transform = ref transformCurrentComponent.Transform;
                
                transform.Translate(transform.right * (Time.deltaTime * movementLinearComponent.Speed), Space.World);
            }
        }
    }
}