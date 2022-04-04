using System;
using Systems;
using Events;
using Leopotam.Ecs;
using UnityEngine;

namespace MonoBehaviours
{
    public class SystemsManager : MonoBehaviour
    {
        EcsWorld _world;
        EcsSystems _systems;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        void Start () {
            _world = new EcsWorld ();
            _systems = new EcsSystems(_world);
            AddSystems();
            _systems.Init ();
        }
    
        void Update () => _systems.Run ();

        void OnDestroy () {
            _systems.Destroy ();
            _world.Destroy ();
        }

        private void AddSystems()
        {
            _systems.Add (new ShipMovementSystem());
            _systems.Add (new ShipRotateSystem());
            _systems.Add(new ShipInitSystem());
            _systems.Add(new EnemyTargetingSystem());
            
            var playerTargetingSystem = new PlayerTargetingSystem();
            EPlayerTargeting.OnTargetClicked.AddListener(playerTargetingSystem.OnClick);
            _systems.Add(playerTargetingSystem);

            _systems.Add(new TurretRotationSystem());
        }
    }
}
