using Components;
using Leopotam.Ecs;
using MonoBehaviours;
using ScriptableObjects;
using UnityEngine;

namespace Systems
{
    public class ShipInitSystem : IEcsInitSystem
    {
        private readonly EcsWorld _world = null;

        public void Init()
        {
            SpawnPlayerShip(new Vector3(0,0,0));
            SpawnEnemyShip(new Vector3(10,0,0));
        }

        private void SpawnPlayerShip(Vector3 position)
        {
            var shipData = ShipScriptableObject.Get();
            var instancedShip = Object.Instantiate(shipData.ShipPrefab, position, Quaternion.identity);
            
            var entity = _world.NewEntity();

            ref var transformComponent = ref entity.Get<TransformComponent>();
            transformComponent.Transform = instancedShip.transform;
            
            ref var movementComponent = ref entity.Get<ShipMovementComponent>();
            movementComponent.Velocity = shipData.Velocity;
            movementComponent.MaxSpeed = shipData.MaxSpeed;

            ref var shipRotateComponent = ref entity.Get<ShipRotateComponent>();
            shipRotateComponent.AngleSpeed = shipData.AngleSpeed;

            ref var targetingComponent = ref entity.Get<TargetingComponent>();
            ref var playerTag = ref entity.Get<PlayerTag>();
            
            ref var turretComponent = ref entity.Get<TurretsComponent>();
            turretComponent.Turrets = instancedShip.TurretList;
        }
        
        private void SpawnEnemyShip(Vector3 position)
        {
            var shipData = ShipScriptableObject.Get();
            var instancedShip = Object.Instantiate(shipData.ShipPrefab, position, Quaternion.identity);
            
            var entity = _world.NewEntity();

            ref var transformComponent = ref entity.Get<TransformComponent>();
            transformComponent.Transform = instancedShip.transform;
            
            ref var movementComponent = ref entity.Get<ShipMovementComponent>();
            movementComponent.Velocity = shipData.Velocity;
            movementComponent.MaxSpeed = shipData.MaxSpeed;
            
            ref var shipRotateComponent = ref entity.Get<ShipRotateComponent>();
            shipRotateComponent.AngleSpeed = shipData.AngleSpeed;

            ref var targetingComponent = ref entity.Get<TargetingComponent>();
            ref var enemyComponent = ref entity.Get<EnemyTag>();
            
            ref var turretComponent = ref entity.Get<TurretsComponent>();
            turretComponent.Turrets = instancedShip.TurretList;
        }
    }
}