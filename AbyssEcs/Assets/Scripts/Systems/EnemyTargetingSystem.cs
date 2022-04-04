using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    public class EnemyTargetingSystem : IEcsInitSystem
    {
        private EcsFilter<EnemyTag, TargetingComponent> _filter;
        private EcsFilter<PlayerTag, TransformComponent> _filter2;

        public void Init()
        {
            foreach (var component in _filter)
            {
                ref var targetingComponent = ref _filter.Get2(component);
                ref var playerTargetingComponent = ref _filter2.Get2(0);
                targetingComponent.Transform = playerTargetingComponent.Transform;
            }
        }
    }
}