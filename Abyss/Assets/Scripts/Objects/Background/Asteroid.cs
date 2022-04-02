using System.Collections.Generic;
using UnityEngine;
using Utilities;

namespace Objects.BackGround
{
    public class Asteroid : MonoBehaviour
    {
        [SerializeField] private List<Sprite> _asteroidsSprites;

        private SpriteRenderer _spriteRenderer;
        private Transform _transform;

        protected void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _transform = GetComponent<Transform>();
        }

        public Asteroid SetRandomSprite()
        {
            _spriteRenderer.sprite = SpriteExtension.GetRandomSpriteFromCollection(_asteroidsSprites);
            return this;
        }
        
        public Asteroid SetRandomAsteroidPositionInRange(float start, float end)
        {
            _transform.localPosition = Randomizer.GetVector3InCircle(start + Random.Range(0, 100), end + start + Random.Range(0, 500));
            _transform.eulerAngles = new Vector3(0,0, 0);
            return this;
        }
    }
}