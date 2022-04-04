using Components;
using Leopotam.Ecs;
using Tags;

namespace Systems
{
    public class EnemyTargetingSystem : IEcsRunSystem
    {
        private EcsFilter<EnemyTag, TargetComponent, EnemyPlayerSpotComponent> _filter;
        private EcsFilter<PlayerTag, TransformComponent> _filter2;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var targetingComponent = ref _filter.Get2(i);
                ref var enemyPlayerSpotComponent = ref _filter.Get3(i);
                ref var isPlayerSpotted = ref enemyPlayerSpotComponent.IsPlayerSpotted;
                
                ref var playerTransformComponent = ref _filter2.Get2(0);

                if (isPlayerSpotted)
                {
                    targetingComponent.Transform = playerTransformComponent.Transform;
                }
            }
        }
    }
}