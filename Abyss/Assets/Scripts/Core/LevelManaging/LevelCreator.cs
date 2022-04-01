using UnityEngine;

namespace Core.LevelManaging
{
    public class LevelCreator
    {
        private readonly LevelManager _levelManager;


        public LevelCreator(LevelManager levelManager) => _levelManager = levelManager;


        public void CreateLevel()
        {
            CreatePlayer();
            CreateStation();
            CreateEnemies();
            CreateAbyss();
        }


        private void CreatePlayer()
        {
            if (_levelManager.InstancedPlayer != null) return;
            var playerShipName = Core.Instance.PlayersAccount.GetPlayersShipName();
            var playersShip = _levelManager.DataBase.TryFindPlayersShip(playerShipName, out var success);
            if (success)
            {
                _levelManager.SetPlayer(_levelManager.Factory.SpawnPlayer(playersShip));
                _levelManager.Factory.SpawnObject(_levelManager.DataBase.GetNavigationCircle());
            }
        }

        private void CreateStation()
        {
            if (_levelManager.DepthCounter % 10 == 0)
            {
                //TODO: Shop
                var shipYard = _levelManager.DataBase.TryGetRandomShipYard(out var success);
                if (success) _levelManager.Factory.SpawnSpaceObjectAtRange(shipYard);
            }

            if (_levelManager.DepthCounter % 5 != 0 || _levelManager.DepthCounter == 0) return;
            {
                var shipYard = _levelManager.DataBase.TryGetRandomShipYard(out var success);
                if (success) _levelManager.Factory.SpawnSpaceObjectAtRange(shipYard);
                
                var repairStation = _levelManager.DataBase.TryGetRandomRepairStation(out var success2);
                if (success2) _levelManager.Factory.SpawnSpaceObjectAtRange(repairStation);
            }
        }

        private void CreateEnemies()
        {
            if (_levelManager.DepthCounter % 10 == 0 || _levelManager.DepthCounter % 5 == 0) return;
            for (var i = 0; i <= _levelManager.DepthCounter; i++)
            {
                var enemyShip = _levelManager.DataBase.TryGetEnemyForDepth(_levelManager.DepthCounter, out var success);
                if (success)
                {
                    _levelManager.Factory.SpawnSpaceObjectAtRange(enemyShip);
                }

                if (_levelManager.DepthCounter >= Random.Range(10, 12)) break;
            }
        }

        private void CreateAbyss()
        {
            var abyss = _levelManager.DataBase.TryGetRandomAbyss(out var succes);
            if (succes) _levelManager.Factory.SpawnSpaceObjectAtRange(abyss);
        }
    }
}