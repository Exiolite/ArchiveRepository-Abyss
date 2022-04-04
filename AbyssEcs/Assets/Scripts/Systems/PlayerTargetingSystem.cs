using Components;
using Leopotam.Ecs;
using Tags;
using UnityEngine;

namespace Systems
{
    public class PlayerTargetingSystem : IEcsInitSystem
    {
        private EcsFilter<PlayerTag, TargetingComponent, TransformComponent> _filter;


        public void Init()
        {
            
        }

        public void OnClick(Transform transform)
        {
            foreach (var i in _filter)
            {
                ref var targetingComponent = ref _filter.Get2(i);
                ref var transformComponent = ref _filter.Get3(i);

                if (transformComponent.Transform == transform)
                {
                    targetingComponent.Transform = null;
                }
                else
                {
                    targetingComponent.Transform = transform;
                }
            }
        }
    }
}