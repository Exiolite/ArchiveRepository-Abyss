using System.Health;
using System.LevelManaging;
using System.Movements;
using System.Navigation;
using System.Turrets;
using UnityEngine;
using Utilities;

namespace System.SpaceObjects
{
    public class Ship : SpaceObject
    {
        public int MinDepth => _minDepth;
        public int MaxDepth => _maxDepth;

        public int ShipPriceCredits => _shipPriceCredits;
        public int ShipPriceMaterials => _shipPriceMaterials;

        //SpaceObject attributes
        [SerializeField] private int _minDepth;
        [SerializeField] private int _maxDepth;
        [SerializeField] private Turret[] _turretBehaviours;
        
        //Modules
        [SerializeField] private Movement _movement;

        public HealthStats HealthStats => _healthStats;
        [SerializeField] private HealthStats _healthStats;
        
        
        //Pricing
        [SerializeField] private int _shipPriceCredits;
        [SerializeField] private int _shipPriceMaterials;

        //Targeting
        private SpaceObject _target;


        private void Update()
        {

            _healthStats.RegenerateShield();
            _movement.MoveShipToTarget(transform, _target);
            
            if (_target == null) return;
            
            if (_target.GetType() != typeof(Ship)) return;
            
            var distanceToTarget = RangeFinder.CalculateDistance(transform, _target);
            if (distanceToTarget > 60) return;
            foreach (var turretBehaviour in _turretBehaviours)
            {
                turretBehaviour.SetTarget(_target);
            }
        }
        
        
        public void SetTarget(SpaceObject target) => _target = target;

        public float GetShipDps()
        {
            float dps = 0;
            
            foreach (var turretBehaviour in _turretBehaviours)
            {
                dps += turretBehaviour.GetDps();
            }

            return dps;
        }

        public void WarpToTarget()
        {
            _movement.MicroWarp(transform, _target);
        }
    }
}