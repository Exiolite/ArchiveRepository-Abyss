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
        var playerTargetingSystem = new PlayerTargetEventSystem();
        EPlayerTargeting.OnTargetClicked.AddListener(playerTargetingSystem.OnClick);
        _systems.Add(playerTargetingSystem);
    }

    private void AddRunSystems()
    {
        _systems.Add(new ShipInitSystem());
        _systems.Add(new CameraInitSystem());
        _systems.Add(new CameraTargetRunSystem());
        _systems.Add(new MovementOffsetRunSystem());
        _systems.Add(new MovementSmoothRunSystem());
        _systems.Add(new MovementLinearRunSystem());
        _systems.Add(new RotateWithSpeedRunSystem());
        _systems.Add(new DelayDestroyRunSystem());
        _systems.Add(new TurretRotationRunSystem());
        _systems.Add(new TurretShootRunSystem());
        _systems.Add(new EnemyPlayerSpotRunSystem());
        _systems.Add(new EnemyTargetRunSystem());
    }
}