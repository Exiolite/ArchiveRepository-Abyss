using System.LevelManaging;
using System.Movements;
using System.NavigationCircle;
using System.PlayerInput.Swipe;
using System.Turrets;
using UnityEngine;
using Utilities;

namespace System.SpaceObjects.Dynamic
{
    public class Ship : SpaceObject
    {
        public int MinDepth => _minDepth;
        public int MaxDepth => _maxDepth;
        
        public HealthStats.HealthStats HealthStats => _healthStats;
        public Movement Movement => _movement;
        
        public int ShipPriceCredits => _shipPriceCredits;
        public int ShipPriceMaterials => _shipPriceMaterials;

        //SpaceObject attributes
        [SerializeField] private int _minDepth;
        [SerializeField] private int _maxDepth;
        [SerializeField] private Turret[] _turretBehaviours;
        
        //Modules
        [SerializeField] private Movement _movement;
        
        //Pricing
        [SerializeField] private int _shipPriceCredits;
        [SerializeField] private int _shipPriceMaterials;
        
        //HealthStats
        [SerializeField] private HealthStats.HealthStats _healthStats;
        private float _damagedTime;
        
        //Particles
        private readonly ParticlesPlayer _particlesPlayer = new ParticlesPlayer();
        private ParticleSystem _shieldParticles;
        
        //Targeting
        private SpaceObject _target;


        
        public void SetTarget(SpaceObject target) => _target = target;

        public void AddParticles(ParticleSystem shieldParticles) => _shieldParticles = shieldParticles;
        
        public void ApplyDamage(float value)
        {
            _particlesPlayer.Play(_shieldParticles);
            _damagedTime = Time.time;
            _healthStats.TryApplyDamage(value, out var haveHp);
            if (!haveHp) return;
            
            if (this == LevelManager.InstancedPlayer)
            {
                LevelEvent.PlayerDeath.Invoke();
                SwipeEvent.SwipedUp.RemoveListener(DoMicroWarp);
            }
            
            NavigationEvent.RemoveArrow.Invoke(this);
            LevelManager.SpawnExplosion(transform);
            LevelManager.SpawnSmallContainer(transform);
            DestroyItSelf();
        }

        public float GetShipDps()
        {
            float dps = 0;
            
            foreach (var turretBehaviour in _turretBehaviours)
            {
                dps += turretBehaviour.GetDps();
            }

            return dps;
        }



        protected override void Initialize()
        {
            base.Initialize();
            LevelManager.AddShieldParticle(this);
            if (this == LevelManager.InstancedPlayer)
            {
                SwipeEvent.SwipedUp.AddListener(DoMicroWarp);
            }
        }
        
        protected override void Execute()
        {
            UpdateBehaviour();
        }


        
        private void UpdateBehaviour()
        {
            if (Time.time > _damagedTime + 1.0f)
            {
                _healthStats.RegenerateShield();
            }
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

        private void DoMicroWarp()
        {
            _movement.MicroWarp(transform, _target);
        }
    }
}