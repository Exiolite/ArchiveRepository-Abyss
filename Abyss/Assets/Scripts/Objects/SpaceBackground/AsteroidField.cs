using System.Collections.Generic;
using UnityEngine;

namespace Objects.SpaceBackground
{
    public class AsteroidField : MonoBehaviour
    {
        [Header("Prefabs")]
        [SerializeField] private Asteroid _asteroid;
        [SerializeField] private int _asteroidsAmount;
        [Header("ChildObjects")]
        [SerializeField] private Transform _asteroidFieldHolderTransform;
        
        
        private List<Asteroid> _instancedAsteroids;


        private void Awake()
        {
            InstantiateAsteroids();
        }
        

        public AsteroidField SetAsteroidsWithInternalSettings()
        {
            foreach (var asteroid in _instancedAsteroids)
            {
                asteroid
                    .SetRandomSprite()
                    .SetRandomAsteroidPositionInRange(400, 1000);
            }
            return this;
        }

        public AsteroidField SetPosition(Vector3 position)
        {
            transform.position = position;
            return this;
        }
        
        public AsteroidField RotateFieldHolderToRandomAngle()
        {
            _asteroidFieldHolderTransform.eulerAngles = new Vector3(Random.Range(0.0f,359.0f),Random.Range(0.0f,359.0f), Random.Range(0.0f,359.0f));
            return this;
        }

        public AsteroidField SetActiveWithChance()
        {
            var asteroidsFieldChance = Random.Range(0.0f, 10);
            _asteroidFieldHolderTransform.gameObject.SetActive(asteroidsFieldChance < 2.5);
            return this;
        }
        
        
        private void InstantiateAsteroids()
        {
            _instancedAsteroids = new List<Asteroid>();
            
            for (var i = 0; i < _asteroidsAmount; i++)
            {
                _instancedAsteroids.Add(Instantiate(_asteroid, _asteroidFieldHolderTransform));
            }
        }
    }
}