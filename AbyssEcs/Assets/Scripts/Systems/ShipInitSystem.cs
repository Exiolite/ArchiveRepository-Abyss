using Components;
using Leopotam.Ecs;
using MonoBehaviours;
using UnityEngine;

namespace Systems
{
    public class ShipInitSystem : IEcsInitSystem
    {
        private readonly EcsWorld _world = null;

        public void Init()
        {
            SpawnPlayerShip();
            SpawnEnemyShip();
        }

        private void SpawnPlayerShip()
        {
            var entity = SpawnShip();
            ref var playerTag = ref entity.Get<PlayerTag>();
        }
        
        private void SpawnEnemyShip()
        {
            var entity = SpawnShip();
            ref var enemyTag = ref entity.Get<EnemyTag>();
        }

        private EcsEntity SpawnShip()
        {
            var shipPrefab = Resources.Load<Ship>("Prefabs/Ships/Ship");
            var instancedShip = Object.Instantiate(shipPrefab, Vector3.zero, Quaternion.identity);
            
            var entity = _world.NewEntity();

            ref var transformComponent = ref entity.Get<TransformComponent>();
            transformComponent.Transform = instancedShip.transform;
            
            ref var movementComponent = ref entity.Get<ShipMovementComponent>();
            movementComponent.Velocity = shipPrefab.Velocity;
            movementComponent.MaxSpeed = shipPrefab.MaxSpeed;

            ref var shipRotateComponent = ref entity.Get<ShipRotateComponent>();
            shipRotateComponent.RotateSpeed = shipPrefab.RotateSpeed;

            ref var targetingComponent = ref entity.Get<TargetingComponent>();
            
            
            ref var turretComponent = ref entity.Get<TurretsComponent>();
            turretComponent.Turrets = instancedShip.TurretList;

            return entity;
        }
    }
}