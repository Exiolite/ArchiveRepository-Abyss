using Components;
using Leopotam.Ecs;

namespace Systems
{
    public class EnemyTargetingSystem : IEcsInitSystem
    {
        private EcsFilter<EnemyTag, TargetingComponent> _filter;
        private EcsFilter<PlayerTag, ShipMovementComponent> _playerComponentFilter;

        public void Init()
        {
            foreach (var component in _filter)
            {
                ref var targetingComponent = ref _filter.Get2(component);
                ref var playerShipMovementComponent = ref _playerComponentFilter.Get2(0);
                targetingComponent.TargetTransform = playerShipMovementComponent.Transform;
            }
        }
    }
}