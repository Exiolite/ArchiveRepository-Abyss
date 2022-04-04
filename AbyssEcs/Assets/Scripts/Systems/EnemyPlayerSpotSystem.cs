using Components;
using Leopotam.Ecs;
using Tags;
using UnityEngine;

namespace Systems
{
    public class EnemyPlayerSpotSystem : IEcsRunSystem
    {
        private EcsFilter<EnemyTag, TransformCurrentComponent, EnemyPlayerSpotComponent> _enemyFilter;
        private EcsFilter<PlayerTag, TransformCurrentComponent> _playerFilter;    
        
        public void Run()
        {
            foreach (var i in _enemyFilter)
            {
                ref var enemyTransformComponent = ref _enemyFilter.Get2(i);
                ref var enemyPlayerSpotComponent = ref _enemyFilter.Get3(i);

                ref var playerTransformComponent = ref _playerFilter.Get2(0);

                if (Vector3.Distance(enemyTransformComponent.Transform.position, playerTransformComponent.Transform.position) < enemyPlayerSpotComponent.Range)
                {
                    enemyPlayerSpotComponent.IsPlayerSpotted = true;
                }
            }
        }
    }
}