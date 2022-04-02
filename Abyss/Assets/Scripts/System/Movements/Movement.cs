using System.SpaceObjects;
using System.SpaceObjects.Dynamic;
using UnityEngine;
using Utilities;

namespace System.Movements
{
    [System.Serializable]
    public class Movement
    {
        [SerializeField] private float _velocity;
        [SerializeField] private float _maxSpeed;
        [SerializeField] private float _angleSpeed;
        
        private float _speed;



        public void HardRotateToTarget(Transform parent, Transform target)
        {
            var directionToTarget = target.transform.position - parent.position;
            var angleToTarget = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg;
            parent.rotation = Quaternion.Euler(0f, 0f, angleToTarget);
        }

        public float GetSpeed()
        {
            return _speed * Time.deltaTime;
        }

        public void SmoothRotateToTarget(Transform parent, Transform target)
        {
            var directionToTarget = target.transform.position - parent.position;
            var angleToTarget = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg;
            var targetRotation = Quaternion.Euler(0,0, angleToTarget);
            parent.rotation = Quaternion.Lerp(parent.rotation, targetRotation, Time.deltaTime * _angleSpeed / 10);
        }
        
        public void HardMoveForward(Transform parent)
        {
            parent.Translate(parent.right * (Time.deltaTime * _maxSpeed), Space.World);
        }
        
        public void HardMoveForwardWithCurrentSpeed(Transform parent)
        {
            parent.position += parent.right * GetSpeed();
        }

        public void HardMoveForwardWithMinSpeed(Transform parent)
        {
            parent.position += parent.right * (Time.deltaTime * 3);
        }

        public void SmoothMoveForward(Transform parent, bool isTargetNotNull)
        {
            if (isTargetNotNull)
            {
                _speed = Mathf.Clamp(_speed + (_velocity * Time.deltaTime), 0, _maxSpeed);
            }
            else
            {
                _speed = Mathf.Clamp(_speed - GetSpeed(), 0, _maxSpeed);
            }
            parent.Translate(parent.right * GetSpeed(), Space.World);
        }

        public void MoveSlowDownToMinSpeed(Transform parent)
        {
            _speed = Mathf.Clamp(_speed - GetSpeed(), 3, _maxSpeed);
            parent.position += parent.right * GetSpeed();
        }

        public void MoveShipToTarget(Transform parent, SpaceObject target)
        {
            if (target == null)
            {
                SmoothMoveForward(parent, false);
                return;
            }
            SmoothRotateToTarget(parent, target.transform);
            if (target.GetType() == typeof(Ship))
            {
                SmoothMoveForward(parent, true);
            }
            else
            {
                if (RangeFinder.CalculateDistance(parent, target)>20)
                {
                    SmoothMoveForward(parent, true);
                }
                else
                {
                    if (RangeFinder.CalculateDistance(parent, target) < 1)
                    {
                        _speed = 0;
                    }
                    else
                    {
                        MoveSlowDownToMinSpeed(parent);
                    }
                }
            }
        }
        
        public void MicroWarp(Transform parent, SpaceObject target)
        {
            if (RangeFinder.CalculateDistance(parent, target) > 50.0f)
            {
                parent.position += parent.right * (RangeFinder.CalculateDistance(parent, target)-50);
            }
        }
    }
}