using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    public class PlayerTargetingSystem : IEcsInitSystem
    {
        private EcsFilter<PlayerTag, TargetingComponent> _filter;


        public void Init()
        {
            
        }

        public void OnClick(Transform transform)
        {
            foreach (var item in _filter)
            {
                ref var targetingComponent = ref _filter.Get2(item);
                targetingComponent.TargetTransform = transform;
            }
        }
    }
}