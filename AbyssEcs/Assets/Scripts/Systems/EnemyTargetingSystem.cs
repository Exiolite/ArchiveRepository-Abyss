using Components;
using Leopotam.Ecs;

namespace Systems
{
    public class EnemyTargetingSystem : IEcsInitSystem
    {
        private EcsFilter<EnemyComponent, TargetingComponent> _enemyComponentFilter;
        private EcsFilter<PlayerComponent, ShipMovementComponent> _playerComponentFilter;

        public void Init()
        {
            foreach (var component in _enemyComponentFilter)
            {
                ref var targetingComponent = ref _enemyComponentFilter.Get2(component);
                ref var playerShipMovementComponent = ref _playerComponentFilter.Get2(0);
                targetingComponent.TargetTransform = playerShipMovementComponent.Transform;
            }
        }
    }
}