using Components;
using Leopotam.Ecs;
using Tags;

namespace Systems
{
    public class CameraTargetRunSystem : IEcsRunSystem
    {
        private EcsFilter<CameraTag, TransformTargetComponent> _cameraFilter;
        private EcsFilter<CameraTargetTag, TransformCurrentComponent> _targetFilter;
        
        public void Run()
        {
            foreach (var i in _cameraFilter)
            {
                ref var cameraTransformTargetComponent = ref _cameraFilter.Get2(i);
                ref var targetTransformCurrentComponent = ref _targetFilter.Get2(0);

                cameraTransformTargetComponent.Transform = targetTransformCurrentComponent.Transform;
            }
        }
    }
}