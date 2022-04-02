using System.Collections.Generic;
using UnityEngine;

namespace Objects.SpaceBackground
{
    public class StarField : MonoBehaviour
    {
        [Header("Prefabs")]
        [SerializeField] private Transform _star;
        
        [Header("Settings")]
        [SerializeField] private int _starsAmount;
        [SerializeField] private int _rangeNumber;
        [SerializeField] private float _maxScale;
        
        
        private List<Transform> _starTransformList;
        

        public StarField InstantiateStars()
        {
            _starTransformList = new List<Transform>();
            for (var i = 0; i < _starsAmount; i++)
            {
                _starTransformList.Add(Instantiate(_star, transform));
            }

            return this;
        }

        public StarField SetStarsPositionAndScale()
        {
            foreach (var starTransform in _starTransformList)
            {
                var scale = Random.Range(0.1f, _maxScale);
                starTransform.localPosition = new Vector3(Random.Range(-_rangeNumber,_rangeNumber), Random.Range(-_rangeNumber,_rangeNumber), 0);
                starTransform.localScale = new Vector3(scale,scale,0);
            }

            return this;
        }
    }
}