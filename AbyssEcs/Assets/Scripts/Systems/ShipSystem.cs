using Components;
using Leopotam.Ecs;
using MonoBehaviours.Data;
using Tags;
using UnityEngine;

namespace Systems
{
    public class ShipSystem : IEcsInitSystem
    {
        private readonly EcsWorld _world = null;

        public void Init()
        {
            SpawnPlayerShip(Vector3.zero);
            SpawnEnemyShip(new Vector3(120, 0,0));
        }

        private void SpawnPlayerShip(Vector3 position)
        {
            var entity = SpawnShip(position);
            ref var playerTag = ref entity.Get<PlayerTag>();
            ref var cameraFollowTag = ref entity.Get<CameraFollowTag>();
        }
        
        private void SpawnEnemyShip(Vector3 position)
        {
            var entity = SpawnShip(position);
            ref var enemyTag = ref entity.Get<EnemyTag>();

            ref var enemyLookRangeComponent = ref entity.Get<EnemyPlayerSpotComponent>();
            enemyLookRangeComponent.Range = 100;
        }

        private EcsEntity SpawnShip(Vector3 position)
        {
            var shipPrefab = Resources.Load<ShipData>("Prefabs/Ships/Ship");
            var instancedShip = Object.Instantiate(shipPrefab, position, Quaternion.identity);
            
            var entity = _world.NewEntity();

            ref var transformComponent = ref entity.Get<TransformComponent>();
            transformComponent.Transform = instancedShip.transform;
            
            ref var movementComponent = ref entity.Get<ShipMovementComponent>();
            movementComponent.Velocity = shipPrefab.Velocity;
            movementComponent.MaxSpeed = shipPrefab.MaxSpeed;

            ref var shipRotateComponent = ref entity.Get<ShipRotateComponent>();
            shipRotateComponent.RotateSpeed = shipPrefab.RotateSpeed;

            ref var targetingComponent = ref entity.Get<TargetComponent>();
            
            
            ref var turretComponent = ref entity.Get<TurretsComponent>();
            turretComponent.Turrets = instancedShip.TurretList;

            return entity;
        }
    }
}