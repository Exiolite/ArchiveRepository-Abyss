using Core;
using Events;
using Objects.SpaceObjects.Dynamic;
using Statics;
using UnityEngine;

namespace Objects.BackGrounds
{
    public class PlanetHandler : BackGroundBehaviour
    {
        [SerializeField] private Sprite[] _planetsSprites;

        [Header("Asteroids field")]
        [SerializeField] private GameObject _asteroidFieldHolder;
        private const float MinDistance = 400.0f;
        [SerializeField] private float _maxDistance;
        [SerializeField] private AsteroidHandler _asteroidHandler;
        
        

        private SpriteRenderer _spriteRenderer;
        private readonly AsteroidHandler[] _instancedAsteroids = new AsteroidHandler[2000];
        
        protected override void Initialize()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _spriteRenderer.sprite = GetRandomPlanetSprite(_spriteRenderer.sprite);

            FirstSpawn();
            
            LevelEvent.DestroyAllExcludePlayer.AddListener(UpdatePlanetAndField);
        }

        protected override void Execute()
        {
            
        }

        private Sprite GetRandomPlanetSprite(Sprite sprite)
        {
            var newSprite = _planetsSprites[GetRandomIndex(_planetsSprites.Length)];
            while (newSprite == sprite)
            {
                newSprite = _planetsSprites[GetRandomIndex(_planetsSprites.Length)];
            }
            return newSprite;
        }

        private int GetRandomIndex(int max)
        {
            return Random.Range(0, max);
        }

        private void FirstSpawn()
        {
            for (int i = 0; i < 2000; i++)
            {
                _instancedAsteroids[i] = SpawnAsteroid();
            }

            UpdateAsteroidsField();
        }
        
        private void UpdatePlanetAndField(Ship garbage)
        {
            var randomX = Random.Range(-800, 800);
            var randomY = Random.Range(-800, 800);
            var randomZ = Random.Range(2500, 5000);
            transform.position = new Vector3(randomX,randomY,randomZ);
            
            _spriteRenderer.sprite = GetRandomPlanetSprite(_spriteRenderer.sprite);
            _spriteRenderer.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));

            var asteroidsFieldChance = Random.Range(0.0f, 10);
            _asteroidFieldHolder.gameObject.SetActive(true);
            UpdateAsteroidsField();
            if (asteroidsFieldChance < 2.5) _asteroidFieldHolder.gameObject.SetActive(false);
        }

        private void UpdateAsteroidsField()
        {
            _asteroidFieldHolder.transform.eulerAngles = new Vector3(Random.Range(0.0f,359.0f),Random.Range(0.0f,359.0f), Random.Range(0.0f,359.0f));
            for (int i = 0; i < 2000; i++)
            {
                SetAsteroid(_instancedAsteroids[i]);
            }
        }
        
        private AsteroidHandler SpawnAsteroid()
        {
            var asteroid = Instantiate(_asteroidHandler, _asteroidFieldHolder.transform);
            return asteroid;
        }

        private void SetAsteroid(AsteroidHandler target)
        {
            target.transform.localPosition = Randomizer.GenerateAsteroids(MinDistance + Random.Range(0, 100), _maxDistance + MinDistance + Random.Range(0, 500));
            target.transform.eulerAngles = new Vector3(0,0, 0);
        }
    }
}