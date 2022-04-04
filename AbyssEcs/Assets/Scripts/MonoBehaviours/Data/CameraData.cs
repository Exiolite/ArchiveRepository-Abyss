using UnityEngine;

namespace MonoBehaviours.Data
{
    public class CameraData : MonoBehaviour
    {
        [Header("Camera settings")]
        [SerializeField] private Vector3 _offset;
        public Vector3 Offset => _offset;
        
        [SerializeField] private float _smoothSpeed;
        public float SmoothSpeed => _smoothSpeed;
    }
}