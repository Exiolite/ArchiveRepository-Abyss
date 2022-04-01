using UnityEngine;

namespace Modules.HealthStats
{
    [System.Serializable]
    public class HealthStats
    {
        public Stat HitPoints => _hitPoints;
        public Stat Shield => _shield;
        
        [SerializeField] private Stat _hitPoints;
        [SerializeField] private Stat _shield;



        public void Add(float hitPointsValue, float shieldValue)
        {
            _hitPoints.Add(hitPointsValue);
            _shield.Add(shieldValue);
        }

        public void RegenerateShield()
        {
            _shield.Regenerate();
        }

        public void TryApplyDamage(float value, out bool isLastShot)
        {
            TryRemoveShield(value, out var success);
            if (!success)
            {
                TryRemoveHitPoints(value, out var haveHp);
                if (!haveHp)
                {
                    isLastShot = true;
                    return;
                }
                isLastShot = false;
            }
            isLastShot = false;
        }
        
        private void TryRemoveHitPoints(float value, out bool success)
        {
            if (_hitPoints.IsEnough(value))
            {
                _hitPoints.Remove(value);
                success = true;
            }
            else
            {
                success = false;
            }
        }
        
        private void TryRemoveShield(float value, out bool success)
        {
            if (_shield.CheckMoreThanZero())
            {
                _shield.Remove(value);
                success = true;
            }
            else
            {
                success = false;
            }
        }
    }
}