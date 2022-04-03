using System.Core;
using System.SpaceBackground;
using System.SpaceObjects;
using UnityEngine;

namespace System.LevelManaging
{
    public class LevelManager
    {
        public int DepthCounter { get; private set; }
        public SpaceObjectsData DataBase { get; }
        public Ship InstancedPlayer { get; private set; }
        public Factory Factory { get; }
        
        private readonly LevelCreator _levelCreator;


        
        public LevelManager(Factory factory)
        {
            Factory = factory;
            DataBase = new SpaceObjectsData();
            _levelCreator = new LevelCreator(this);
            ESpaceBackground.InstantiateSpaceBackground.Invoke();
        }

        
        
        public void ManageLevelCreation()
        {
            _levelCreator.CreateLevel();
            DepthCounter++;
        }

        public void SetPlayer(Ship target)
        {
            InstancedPlayer = target;
        }

        public void CreateNextLevel()
        {
            LevelEvent.DestructAllSpaceObjects.Invoke();
            ESpaceBackground.RandomizeSpaceBackground.Invoke();
            InstancedPlayer.transform.position = new Vector3(0,0,0);
            Factory.ResetId(true);
            _levelCreator.CreateLevel();
            DepthCounter++;
        }

        public void ResetLevels()
        {
            InstancedPlayer = null;
            DepthCounter = 0;
            LevelEvent.DestructAllSpaceObjects.Invoke();
            Factory.ResetId(true);
            _levelCreator.CreateLevel();
            DepthCounter++;
        }

        public void SpawnSmallContainer(Transform parent)
        {
            var container = DataBase.TryGetSmallContainer(out var success);
            if (success) Factory.SpawnSpaceObjectAtTransform(container, parent);
        }

        public void AddShieldParticle(Ship parent)
        {
            var shieldParticles = DataBase.TryGetShieldDamageEffect(out var success);
            if (success) Factory.SpawnParticlesAtTransform(parent, shieldParticles);
        }

        public Ship SpawnShipOnShipYard(Transform transform, Ship ship)
        {
            var marketShip = DataBase.TryFindPlayersShip(ship.ObjName, out var success);
            return (Ship)Factory.SpawnSpaceObjectAtTransform(marketShip, transform);
        }

        public void SetPlayersShip(Ship target)
        {
            var previousShip = (SpaceObject)InstancedPlayer;
            InstancedPlayer = target;
        }

        public void SpawnExplosion(Transform transform)
        {
            var explosion = DataBase.GetExplosionObject();
            Factory.SpawnObjectAtTransformDetached(explosion, transform);
        }
    }
}