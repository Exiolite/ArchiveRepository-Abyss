using System.Collections.Generic;
using UnityEngine;
using Utilities;
using Utilities.Extension;

namespace System.SpaceBackground
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
            _transform.localPosition = Vector3Extension.GetRangedVector3InShapeOfCircle(start + UnityEngine.Random.Range(0, 100), end + start + UnityEngine.Random.Range(0, 500));
            _transform.eulerAngles = new Vector3(0,0, 0);
            return this;
        }
    }
}