using UnityEngine;

namespace Abstractions
{
    [System.Serializable]
    public class Damage
    {
        [SerializeField, Range(0, 100)] private float _amount;
        public float Amount => _amount;
    }
}