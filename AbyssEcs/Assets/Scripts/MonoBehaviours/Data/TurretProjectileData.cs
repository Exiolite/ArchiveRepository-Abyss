using Abstractions;
using UnityEngine;

namespace MonoBehaviours.Data
{
    public class TurretProjectileData : MonoBehaviour
    {
        [SerializeField] private Damage _damage;
        public Damage Damage => _damage;
    }
}