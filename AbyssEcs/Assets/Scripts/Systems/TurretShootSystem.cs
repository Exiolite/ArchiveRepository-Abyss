using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    public class TurretShootSystem : IEcsRunSystem
    {
        private EcsWorld _world;
        private EcsFilter<TurretsComponent, TransformTargetComponent, TransformCurrentComponent> _filter;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var turretsComponent = ref _filter.Get1(i);
                ref var transformTargetComponent = ref _filter.Get2(i);
                ref var transformCurrentComponent = ref _filter.Get3(i);

                if (transformTargetComponent.Transform)
                {
                    foreach (var turret in turretsComponent.Turrets)
                    {
                        var turretProjectileData = turret.TurretProjectileData;
                    
                        if (Vector3.Distance(transformCurrentComponent.Transform.position, transformTargetComponent.Transform.position) < turretProjectileData.Range)
                        {
                            var turretTransform = turret.transform;
                            var instancedTurretProjectile = Object.Instantiate(turretProjectileData, turretTransform.position, turretTransform.rotation);
                        
                            var entityProjectile = _world.NewEntity();
                            ref var transformComponent = ref entityProjectile.Get<TransformCurrentComponent>();
                            transformComponent.Transform = instancedTurretProjectile.transform;
                            ref var movementLinearComponent = ref entityProjectile.Get<MovementLinearComponent>();
                            movementLinearComponent.Speed = turretProjectileData.Speed;
                            ref var delayDestroyComponent = ref entityProjectile.Get<DelayDestroyComponent>();
                            delayDestroyComponent.Lifetime = turretProjectileData.Lifetime;
                            delayDestroyComponent.CreateTime = Time.time;
                        }
                    }
                }
            }
        }
    }
}