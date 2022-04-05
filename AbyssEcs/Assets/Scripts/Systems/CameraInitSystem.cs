using Components;
using Leopotam.Ecs;
using MonoBehaviours.Data;
using Tags;
using UnityEngine;

namespace Systems
{
    public class CameraInitSystem : IEcsInitSystem
    {
        private EcsWorld _world;


        public void Init()
        {
            var cameraPrefab = Resources.Load<CameraData>("Prefabs/Camera");
            var instancedCamera = Object.Instantiate(cameraPrefab, Vector3.zero, Quaternion.identity);
            var entity = _world.NewEntity();

            ref var transformCurrentComponent = ref entity.Get<TransformCurrentComponent>();
            transformCurrentComponent.Transform = instancedCamera.transform;

            ref var transformTargetComponent = ref entity.Get<TransformTargetComponent>();

            ref var smoothMovementComponent = ref entity.Get<MovementOffsetComponent>();
            smoothMovementComponent.Offset = cameraPrefab.Offset;
            smoothMovementComponent.SmoothSpeed = cameraPrefab.SmoothSpeed;

            ref var cameraTag = ref entity.Get<CameraTag>();
        }
    }
}