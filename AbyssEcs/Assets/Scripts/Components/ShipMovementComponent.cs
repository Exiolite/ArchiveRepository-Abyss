using UnityEngine;

namespace Components
{
    public struct ShipMovementComponent
    {
        public Transform Transform;
        public float CurrentSpeed;
        public float MaxSpeed;
        public float Velocity;
        public float AngleSpeed;
    }
}