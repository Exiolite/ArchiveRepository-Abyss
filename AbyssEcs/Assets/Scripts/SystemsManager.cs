using Systems;
using Events;
using Leopotam.Ecs;
using MonoBehaviours;
using UnityEngine;

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
        AddRunSystems();
        AddSystemsWithUnityEvents();
        _systems.Init ();
    }
    
    void Update () => _systems.Run ();

    void OnDestroy () {
        _systems.Destroy ();
        _world.Destroy ();
    }


    private void AddSystemsWithUnityEvents()
    {
        var playerTargetingSystem = new PlayerTargetingSystem();
        EPlayerTargeting.OnTargetClicked.AddListener(playerTargetingSystem.OnClick);
        _systems.Add(playerTargetingSystem);
    }

    private void AddRunSystems()
    {
        _systems.Add(new CameraMovementSystem());
        _systems.Add(new EnemyPlayerSpotSystem());
        _systems.Add(new EnemyTargetingSystem());
        _systems.Add(new ShipSystem());
        _systems.Add(new MovementSmoothSystem());
        _systems.Add(new MovementLinearSystem());
        _systems.Add(new RotateWithSpeedSystem());
        _systems.Add(new TurretRotationSystem());
        _systems.Add(new TurretShootSystem());
        _systems.Add(new DelayDestroySystem());
    }
}