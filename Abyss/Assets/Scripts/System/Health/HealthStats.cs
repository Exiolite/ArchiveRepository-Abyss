using System.SpaceObjects;
using UnityEngine;

namespace System.Health
{
    [Serializable]
    public class HealthStats
    {
        public Stat HitPoints => _hitPoints;
        public Stat Shield => _shield;
        
        [SerializeField] private Stat _hitPoints;
        [SerializeField] private Stat _shield;


        private SpaceObject _parentSpaceObject;
        

        public HealthStats(SpaceObject parent)
        {
            _parentSpaceObject = parent;
        }


        public void Add(float hitPointsValue, float shieldValue)
        {
            _hitPoints.Add(hitPointsValue);
            _shield.Add(shieldValue);
        }

        public void RegenerateShield()
        {
            _shield.Regenerate();
        }

        public void TryApplyDamage(Damage damage)
        {
            if (TryRemoveShield(damage.GetDamage()))
            {
                if (TryRemoveHitPoints(damage.GetDamage()))
                {
                    
                    return;
                }
            }
        }
        
        private bool TryRemoveHitPoints(float value)
        {
            if (!_hitPoints.IsEnough(value)) return false;
            _hitPoints.Remove(value);
            return true;
        }
        
        private bool TryRemoveShield(float value)
        {
            if (!_shield.IsEnough(value)) return false;
            _shield.Remove(value);
            return true;
        }
    }
}