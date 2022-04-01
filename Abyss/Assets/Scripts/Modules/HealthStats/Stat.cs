using System;
using UnityEngine;

namespace Modules.HealthStats
{
    [System.Serializable]
    public class Stat
    {
        public float StatValue => _statValue;
        
        [SerializeField] private float _statValue;
        [SerializeField] private float _maxStatValue;
        [SerializeField] private float _regenerateValue;


        public float GetPercent() => _statValue / _maxStatValue;
        
        public int GetDifference() => (int)_maxStatValue - (int)_statValue;

        
        public void Set(float value) => _statValue = value;
        
        
        public void Add(float value) => _statValue = Mathf.Clamp(_statValue + value, 0, _maxStatValue);

        public void Regenerate() => _statValue = Mathf.Clamp(_statValue + (_regenerateValue * Time.deltaTime), 0, _maxStatValue);
        
        public void Remove(float value) => _statValue = Mathf.Clamp(_statValue - value, 0, _maxStatValue);


        public bool IsEnough(float value) => _statValue > value;

        public bool CheckMoreThanZero() => _statValue > 0;

        public bool CheckIfFull() => Math.Abs(_statValue - _maxStatValue) < 0.0001f;
    }
}