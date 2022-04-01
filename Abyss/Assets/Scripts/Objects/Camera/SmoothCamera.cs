using Core;
using UnityEngine;

namespace Objects.Camera
{
    public class SmoothCamera : ObjectBehaviour
    {
        [SerializeField] private float _smoothSpeed = 3;
        [SerializeField] private Vector3 _offset;


        private void LateUpdate()
        {
            if (LevelManager.InstancedPlayer == null) return;
            var desiredPosition = LevelManager.InstancedPlayer.transform.position + _offset;
            var smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;
        }

        protected override void Initialize()
        {
        }

        protected override void Execute()
        {
        }
    }
}