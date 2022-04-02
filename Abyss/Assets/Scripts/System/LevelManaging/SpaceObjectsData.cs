using System.Collections.Generic;
using System.Effects;
using System.Linq;
using System.SpaceObjects;
using System.SpaceObjects.Dynamic;
using UnityEngine;

namespace System.LevelManaging
{
    public class SpaceObjectsData
    {
        public Ship[] MarketShips => _marketShips;
        
        private readonly List<SpaceObject> _allSpaceObjects = new List<SpaceObject>();
        private Ship[] _enemiesShips;
        private Ship[] _marketShips;
        private SpaceObject[] _abysses;
        private SpaceObject[] _containersSmall;
        private SpaceObject[] _containersMedium;
        private SpaceObject[] _containersBig;
        private SpaceObject[] _repairStations;
        private SpaceObject[] _shipYards;
        private SpaceObject[] _shops;

        private NavigationCircle.NavigationCircle _navigationCircle;

        private ParticleSystem _shieldDamage;
        private ShipExplode _shipExplode;


        public SpaceObjectsData()
        {
            LoadResources();
        }
        
        
        //NavigationCircle
        public GameObject GetNavigationCircle()
        {
            return _navigationCircle.gameObject;
        }
        
        //Effects
        public ParticleSystem TryGetShieldDamageEffect(out bool success)
        {
            if (_shieldDamage != null)
            {
                success = true;
                return _shieldDamage;
            }
            success = false;
            return null;
        }
        
        //Ships
        public Ship TryFindPlayersShip(string shipName, out bool success)
        {
            return (Ship)TryFindObjectByName(shipName, out success);
        }

        public Ship TryGetEnemyForDepth(int depth, out bool success)
        {
            var depthShips = new List<Ship>();
            foreach (var enemiesShip in _enemiesShips)
            {
                if (enemiesShip.MaxDepth >= depth && depth >= enemiesShip.MinDepth)
                {
                    depthShips.Add(enemiesShip);
                }
            }

            if (depthShips.Count > 0)
            {
                success = true;
                return depthShips[UnityEngine.Random.Range(0, depthShips.Count)];
            }
            success = false;
            return null;
        }

        public Ship GetRandomMarketShip()
        {
            if (_marketShips.Length == 0) throw new System.Exception("There is no ships in marketShips array");

            var randomShip = _marketShips[UnityEngine.Random.Range(0, _marketShips.Length)];
            return randomShip;
        }

        public SpaceObject TryGetSmallContainer(out bool success)
        {
            var spaceObject = TryGetRandomObject(_containersSmall, out success);
            if (success) return spaceObject;
            success = false;
            return null;
        }
        
        //Stations
        public SpaceObject TryGetRandomRepairStation(out bool success)
        {
            var spaceObject = TryGetRandomObject(_repairStations, out success);
            if (success) return spaceObject;
            success = false;
            return null;
        }
        
        public SpaceObject TryGetRandomShipYard(out bool success)
        {
            var spaceObject = TryGetRandomObject(_shipYards, out success);
            if (success) return spaceObject;
            success = false;
            return null;
        }
        
        public SpaceObject TryGetRandomShop(out bool success)
        {
            var spaceObject = TryGetRandomObject(_shops, out success);
            if (success) return spaceObject;
            success = false;
            return null;
        }
        
        public SpaceObject TryGetRandomAbyss(out bool success)
        {
            var spaceObject = TryGetRandomObject(_abysses, out success);
            if (success) return spaceObject;
            success = false;
            return null;
        }

        public GameObject GetExplosionObject()
        {
            return _shipExplode.gameObject;
        }



        private SpaceObject TryGetRandomObject(SpaceObject[] spaceObjects, out bool success)
        {
            if (spaceObjects.Length == 0)
            {
                success = false;
                return null;
            }
            success = true;
            return spaceObjects[UnityEngine.Random.Range(0, spaceObjects.Length)];
        }
        
        private SpaceObject TryFindObjectByName(string objectName, out bool success)
        {
            foreach (var spaceObject in _allSpaceObjects.Where(spaceObject => objectName == spaceObject.ObjName))
            {
                success = true;
                return spaceObject;
            }
            success = false;
            return null;
        }

        private void LoadResources()
        {
            _enemiesShips = UnityEngine.Resources.LoadAll<Ship>("Prefabs/SpaceObjects/Dynamic/EnemiesShips/");
            _marketShips = UnityEngine.Resources.LoadAll<Ship>("Prefabs/SpaceObjects/Dynamic/MarketShips/");
            _abysses = UnityEngine.Resources.LoadAll<SpaceObject>("Prefabs/SpaceObjects/Static/Abysses/");
            _containersSmall = UnityEngine.Resources.LoadAll<SpaceObject>("Prefabs/SpaceObjects/Static/Containers/Small/");
            _containersMedium = UnityEngine.Resources.LoadAll<SpaceObject>("Prefabs/SpaceObjects/Static/Containers/Medium/");
            _containersBig = UnityEngine.Resources.LoadAll<SpaceObject>("Prefabs/SpaceObjects/Static/Containers/Big/");
            _repairStations = UnityEngine.Resources.LoadAll<SpaceObject>("Prefabs/SpaceObjects/Static/RepairStations/");
            _shipYards = UnityEngine.Resources.LoadAll<SpaceObject>("Prefabs/SpaceObjects/Static/ShipYards/");
            _shops = UnityEngine.Resources.LoadAll<SpaceObject>("Prefabs/SpaceObjects/Static/Shops/");
            
            _navigationCircle = UnityEngine.Resources.Load<NavigationCircle.NavigationCircle>("Prefabs/NavigationCircle/NavigationCircle");
            
            _shieldDamage = UnityEngine.Resources.Load<ParticleSystem>("Prefabs/Effects/Particles/ShieldDamage");
            _shipExplode = UnityEngine.Resources.Load<ShipExplode>("Prefabs/Effects/Particles/ShipExplosion");


            //Crutch resource load to list //TODO: TBD Resource Load
            foreach (var enemiesShip in _enemiesShips)
            {
                _allSpaceObjects.Add(enemiesShip);
            }

            foreach (var marketShip in _marketShips)
            {
                _allSpaceObjects.Add(marketShip);
            }

            foreach (var abyss in _abysses)
            {
                _allSpaceObjects.Add(abyss);
            }

            foreach (var container in _containersSmall)
            {
                _allSpaceObjects.Add(container);
            }

            foreach (var container in _containersMedium)
            {
                _allSpaceObjects.Add(container);
            }

            foreach (var container in _containersBig)
            {
                _allSpaceObjects.Add(container);
            }

            foreach (var repairStation in _repairStations)
            {
                _allSpaceObjects.Add(repairStation);
            }

            foreach (var shipYard in _shipYards)
            {
                _allSpaceObjects.Add(shipYard);
            }

            foreach (var shop in _shops)
            {
                _allSpaceObjects.Add(shop);
            }
        }
    }
}