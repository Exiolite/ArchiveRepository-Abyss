using UnityEngine;

namespace MonoBehaviours.Data
{
    public class TurretProjectileData : MonoBehaviour
    {
        [SerializeField, Min(0)] private float _damage;
        public float Damage => _damage;

        [SerializeField] private float _range;
        public float Range => _range;
        
        [SerializeField, Min(0)] private float _speed;
        public float Speed => _speed;

        [SerializeField, Range(0, 5)] private int _lifetime;
        public int Lifetime => _lifetime;
    }
}