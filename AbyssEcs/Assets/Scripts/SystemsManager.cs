using Systems;
using Events;
using Leopotam.Ecs;
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
        AddInitSystems();
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
        
    private void AddInitSystems()
    {
        _systems.Add(new ShipInitSystem());
    }
        
    private void AddRunSystems()
    {
        _systems.Add(new ShipMovementSystem());
        _systems.Add(new ShipRotateSystem());
        _systems.Add(new TurretRotationSystem());
        _systems.Add(new EnemyTargetingSystem());
    }
}