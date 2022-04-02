using UnityEngine;

namespace System.Camera
{
    public class SmoothCamera : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private float _smoothSpeed = 3;
        [SerializeField] private Vector3 _offset;

        private Transform _transform;
        private Transform _targetTransform;
        private bool _isFollowActive;


        private void Awake()
        {
            _transform = GetComponent<Transform>();
            
            ECamera.SetTargetTransform.AddListener(SetTargetTransform);
            ECamera.ResetTargetTransform.AddListener(ResetTargetTransform);
            ECamera.StartNavigationCircleFollowTarget.AddListener(StartFollowTarget);
            ECamera.StopFollowTarget.AddListener(StopFollowTarget);
        }
        
        private void LateUpdate()
        {
            if (_isFollowActive)
            {
                var desiredPosition = _targetTransform.position + _offset;
                var smoothedPosition = Vector3.Lerp(_transform.position, desiredPosition, _smoothSpeed * Time.deltaTime);
                _transform.position = smoothedPosition;
            }
        }
        

        private void SetTargetTransform(Transform targetTransform)
        {
            _targetTransform = targetTransform;
        }
        
        private void ResetTargetTransform()
        {
            _targetTransform = null;
        }
        
        private void StartFollowTarget()
        {
            _isFollowActive = true;
        }

        private void StopFollowTarget()
        {
            _isFollowActive = false;
        }
    }
}