using System.Collections.Generic;
using UnityEngine;
using Utilities;
using Utilities.Builder;
using Utilities.Extension;

namespace System.SpaceBackground
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
            _spriteRenderer.color = new Color(UnityEngine.Random.Range(0.0f, 1.0f), UnityEngine.Random.Range(0.0f, 1.0f), UnityEngine.Random.Range(0.0f, 1.0f));
            return this;
        }
    }
}