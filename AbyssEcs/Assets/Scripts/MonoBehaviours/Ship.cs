using System.Collections.Generic;
using UnityEngine;

namespace MonoBehaviours
{
    public class Ship : MonoBehaviour
    {
        [Header("Description")]
        [SerializeField] private string _name;
        public string Name => _name;

        [SerializeField] private string _description;
        public string Description => _description;

        [Header("Engine")]
        [SerializeField] private float _maxSpeed;
        public float MaxSpeed => _maxSpeed;

        [SerializeField] private float _velocity;
        public float Velocity => _velocity;

        [Header("Shunting engines")]
        [SerializeField] private float _rotateSpeed;
        public float RotateSpeed => _rotateSpeed;
        
        [Header("Turrets")]
        [SerializeField] private List<Turret> _turretList;
        public List<Turret> TurretList => _turretList;
    }
}