using Core;
using UnityEngine;

namespace Objects.BackGrounds
{
    public class AsteroidHandler : BackGroundBehaviour
    {
        [SerializeField] private Sprite[] _asteroidsSprites;

        private SpriteRenderer _spriteRenderer;

        protected override void Initialize()
        {
            base.Initialize();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _spriteRenderer.sprite = _asteroidsSprites[Random.Range(0, _asteroidsSprites.Length)];
        }
    }
}