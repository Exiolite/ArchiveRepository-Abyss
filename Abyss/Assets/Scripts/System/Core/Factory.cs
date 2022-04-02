using System.SpaceObjects;
using System.SpaceObjects.Dynamic;
using UnityEngine;
using Utilities;
using Utilities.Extension;

namespace System.Core
{
    public class Factory : ObjectBehaviour
    {
        private readonly string _objectPreIndex = "IO";
        private int _objectId;
        
        
        
        protected override void Initialize(){}
        protected override void Execute(){}
        
        
        
        public void SpawnObject(GameObject target)
        {
            var spawnedObject = Instantiate(target);
        }

        public void SpawnObjectAtTransformDetached(GameObject target, Transform parentTransform)
        {
            var spawnedObject = Instantiate(target, parentTransform);
            spawnedObject.transform.parent = null;
        }

        public void SpawnParticlesAtTransform(Ship target, ParticleSystem targetParticles)
        {
            var particles = Instantiate(targetParticles, target.transform);
            target.AddParticles(particles);
        }

        public SpaceObject SpawnSpaceObjectAtTransform(SpaceObject target, Transform parentTransform)
        {
            var spawnedObject = Instantiate(target, parentTransform);
            spawnedObject.transform.parent = null;
            SetObjectId(spawnedObject.gameObject);
            return spawnedObject;
        }
        
        public void SpawnSpaceObjectAtRange(SpaceObject target)
        {
            var spawnedObject = Instantiate(target);
            SetObjectId(spawnedObject.gameObject);
            spawnedObject.transform.position = Vector3Extension.GetRandomVector3InRangeOfSquare(200,1000);
        }

        public Ship SpawnPlayer(Ship ship)
        {
            var spawnedObject = Instantiate(ship);
            SetObjectId(spawnedObject.gameObject);
            return spawnedObject;
        }

        public void ResetId(bool isPlayerAlive)
        {
            _objectId = isPlayerAlive ? 1 : 0;
        }
        
        
        
        private void SetObjectId(GameObject spawnedObject)
        {
            spawnedObject.name = _objectPreIndex + _objectId;
            _objectId++;
        }
    }
}