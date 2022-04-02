using UnityEngine;

namespace System.SpaceBackground
{
    public class SpaceBackgroundService : MonoBehaviour
    {
        [Header("Prefabs")]
        [SerializeField] private Planet _planet;
        private Planet _instancedPlanet;
        
        [SerializeField] private AsteroidField _asteroidField;
        private AsteroidField _instancedAsteroidField;

        [SerializeField] private StarField _starField;
        private StarField _instancedStarField;
        
        
        private void Awake()
        {
            ESpaceBackground.InstantiateSpaceBackground.AddListener(InstantiateSpaceBackground);
            ESpaceBackground.RandomizeSpaceBackground.AddListener(InitializeSpaceBackground);
        }

        
        private void InstantiateSpaceBackground()
        {
            _instancedPlanet = Instantiate(_planet, transform);
            _instancedAsteroidField = Instantiate(_asteroidField, transform);
            _instancedStarField = Instantiate(_starField, transform);
        }
        
        private void InitializeSpaceBackground()
        {
            _instancedPlanet
                .SetPositionFromInternalSettings()
                .SetRandomSprite()
                .SetRandomColor();

            _instancedAsteroidField
                .SetPosition(_instancedPlanet.transform.position)
                .SetAsteroidsWithInternalSettings()
                .RotateFieldHolderToRandomAngle()
                .SetActiveWithChance();

            _instancedStarField
                .InstantiateStars()
                .SetStarsPositionAndScale();
        }
    }
}