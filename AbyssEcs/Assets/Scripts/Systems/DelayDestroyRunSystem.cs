using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    public class DelayDestroyRunSystem : IEcsRunSystem
    {
        private EcsWorld _world;
        private EcsFilter<DelayDestroyComponent, TransformCurrentComponent> _filter;
        
        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var delayDestroyComponent = ref _filter.Get1(i);
                ref var entity = ref _filter.GetEntity(i);
                if (Time.time > delayDestroyComponent.CreateTime + delayDestroyComponent.Lifetime)
                {
                    ref var targetTransformCurrentComponent = ref entity.Get<TransformCurrentComponent>();
                    Object.Destroy(targetTransformCurrentComponent.Transform.gameObject);
                    entity.Destroy();
                }
            }
        }
    }
}