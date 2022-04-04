using Components;
using Leopotam.Ecs;
using MonoBehaviours;
using MonoBehaviours.Data;
using Tags;
using UnityEngine;

namespace Systems
{
    public class CameraMovementSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsWorld _world;
        
        private EcsFilter<CameraTag, TransformCurrentComponent, MovementOffsetComponent> _filter;
        private EcsFilter<CameraFollowTag, TransformCurrentComponent> _filter2;

        public void Init()
        {
            var cameraPrefab = Resources.Load<CameraData>("Prefabs/Camera");
            var instancedCamera = Object.Instantiate(cameraPrefab, Vector3.zero, Quaternion.identity);
            var entity = _world.NewEntity();

            ref var transformComponent = ref entity.Get<TransformCurrentComponent>();
            transformComponent.Transform = instancedCamera.transform;

            ref var smoothMovementComponent = ref entity.Get<MovementOffsetComponent>();
            smoothMovementComponent.Offset = cameraPrefab.Offset;
            smoothMovementComponent.SmoothSpeed = cameraPrefab.SmoothSpeed;

            ref var cameraTag = ref entity.Get<CameraTag>();
        }
        
        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var transformComponent = ref _filter.Get2(i);
                ref var smoothMovementComponent = ref _filter.Get3(i);
                ref var targetTransformComponent = ref _filter2.Get2(i);

                if (targetTransformComponent.Transform)
                {
                    var desiredPosition = targetTransformComponent.Transform.position + smoothMovementComponent.Offset;
                    var smoothedPosition = Vector3.Lerp(transformComponent.Transform.position, desiredPosition, smoothMovementComponent.SmoothSpeed * Time.deltaTime);
                    transformComponent.Transform.position = smoothedPosition;
                }
            }
        } }
}