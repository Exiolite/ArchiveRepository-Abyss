using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Ship", menuName = "SpaceObject/Ship", order = 51)]
    public class ShipScriptableObject : ScriptableObject
    {
        public GameObject ShipPrefab => _shipPrefab;
        [SerializeField] private GameObject _shipPrefab;
        
        public float MaxSpeed => _maxSpeed;
        [SerializeField] private float _maxSpeed;
        
        public float Velocity => _velocity;
        [SerializeField] private float _velocity;
        
        public float AngleSpeed => _angleSpeed;
        [SerializeField] private float _angleSpeed;

        public static ShipScriptableObject Get()
        {
            return Resources.Load("Data/Test") as ShipScriptableObject;
        }
    }
}