using System.Collections.Generic;
using UnityEngine;

namespace MonoBehaviours
{
    public class Ship : MonoBehaviour
    {
        public List<Turret> TurretList => _turretList;
        [SerializeField] private List<Turret> _turretList;
    }
}