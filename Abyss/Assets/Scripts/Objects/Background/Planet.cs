using System.Collections.Generic;
using JetBrains.Annotations;
using Objects.BackGround;
using Objects.SpaceObjects.Dynamic;
using UnityEngine;
using UnityEngine.Serialization;
using Utilities;

namespace Objects.Background
{
    public class Planet : MonoBehaviour
    {
        [SerializeField] private List<Sprite> _planetsSprites;
        [SerializeField] private int _verticalAndHorizontalMax;
        [SerializeField] private int _maxDepth;
        [SerializeField] private int _minDepth;
        
        private SpriteRenderer _spriteRenderer;

        
        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        
        public Planet SetPositionFromInternalSettings()
        {
            transform.position = new Vector3Builder()
                .SetRandomRangeOfX(-_verticalAndHorizontalMax, _verticalAndHorizontalMax)
                .SetRandomRangeOfY(-_verticalAndHorizontalMax, _verticalAndHorizontalMax)
                .SetRandomRangeOfZ(_minDepth, _maxDepth)
                .ToVector();

            return this;
        }

        public Planet SetRandomSprite()
        {
            _spriteRenderer.sprite = SpriteExtension.GetRandomSpriteFromCollection(_planetsSprites);
            return this;
        }

        public Planet SetRandomColor()
        {
            _spriteRenderer.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
            return this;
        }
    }
}