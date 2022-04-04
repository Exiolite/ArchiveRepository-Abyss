using UnityEngine;

namespace MonoBehaviours.Data
{
    public class TurretData : MonoBehaviour
    {
        [Header("Projectile")]
        [SerializeField] private TurretProjectileData _turretProjectileData;
        public TurretProjectileData TurretProjectileData => _turretProjectileData;
    }
}