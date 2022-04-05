using Components;
using Leopotam.Ecs;
using MonoBehaviours.Data;
using Tags;
using UnityEngine;

namespace Systems
{
    public class ShipInitSystem : IEcsInitSystem
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
            ref var cameraTargetTag = ref entity.Get<CameraTargetTag>();
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

            ref var transformCurrentComponent = ref entity.Get<TransformCurrentComponent>();
            transformCurrentComponent.Transform = instancedShip.transform;
            ref var transformTargetComponent = ref entity.Get<TransformTargetComponent>();
            
            ref var movementComponent = ref entity.Get<MovementSmoothComponent>();
            movementComponent.Velocity = shipPrefab.Velocity;
            movementComponent.MaxSpeed = shipPrefab.MaxSpeed;

            ref var shipRotateComponent = ref entity.Get<RotateWithSpeedComponent>();
            shipRotateComponent.RotateSpeed = shipPrefab.RotateSpeed;

            ref var turretsComponent = ref entity.Get<TurretsComponent>();
            turretsComponent.Turrets = instancedShip.TurretList;

            return entity;
        }
    }
}