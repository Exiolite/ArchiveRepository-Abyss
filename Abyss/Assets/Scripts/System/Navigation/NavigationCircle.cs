using System.Collections.Generic;
using System.Gui.Components;
using System.LevelManaging;
using System.Linq;
using System.SpaceObjects;
using System.SpaceObjects.Dynamic;
using UnityEngine;

namespace System.Navigation
{
    public class NavigationCircle : MonoBehaviour
    {
        // Settings
        [Header("Prefabs")]
        [SerializeField] private NavigationArrow _navigationArrow;
        
        [Header("Child")]
        [SerializeField] private GImageFiller _hitPoints;
        [SerializeField] private GImageFiller _shield;

        // Components
        private Transform _transform;
        
        // Logic
        private List<NavigationArrow> _instancedArrowList;
        
        // Following attributes
        private Ship _targetShip;
        private Transform _targetShipTransform;
        private bool _isTargetInitialized;
        

        private void Awake()
        {
            _transform = GetComponent<Transform>();
            _instancedArrowList = new List<NavigationArrow>();
            
            ENavigationCircle.AddNavigationCircleTarget.AddListener(AddNavigationCircleTarget);
            ENavigationCircle.RemoveNavigationCircleTarget.AddListener(RemoveNavigationCircleTarget);
            ENavigationCircle.SetNavigationCircleFollowTarget.AddListener(SetNavigationCircleFollowTarget);
            ENavigationCircle.StartNavigationCircleFollowTarget.AddListener(StartNavigationCircleFollowTarget);
            ENavigationCircle.StopNavigationCircleFollowTarget.AddListener(StopNavigationCircleFollowTarget);
            LevelEvent.PlayerDeath.AddListener(DestroyItSelf);
        }
        
        private void Update()
        {
            if (_isTargetInitialized)
            {
                _hitPoints.SetImageFill(_targetShip.HealthStats.HitPoints.GetPercent());
                _shield.SetImageFill(_targetShip.HealthStats.Shield.GetPercent());
                _transform.position = _targetShipTransform.position;
            }
        }
        
        
        private void AddNavigationCircleTarget(SpaceObject target)
        {
            var arrow = Instantiate(_navigationArrow, transform);
            _instancedArrowList.Add(arrow);
            arrow.SetTarget(target);
        }

        private void RemoveNavigationCircleTarget(SpaceObject target)
        {
            if (_instancedArrowList == null) throw new Exception("Collection is not initialized");
            if (_instancedArrowList.Count == 0) throw new Exception("Collection must contain at least one item");

            var navigationArrow = _instancedArrowList.FirstOrDefault(o => o.Target == target);
            _instancedArrowList.Remove(navigationArrow);
        }
        
        private void SetNavigationCircleFollowTarget(Ship target)
        {
            _targetShip = target;
            _targetShipTransform = target.transform;
        }
        
        private void StartNavigationCircleFollowTarget()
        {
            _isTargetInitialized = true;
        }

        private void StopNavigationCircleFollowTarget()
        {
            _isTargetInitialized = false;
        }
        
        private void DestroyItSelf()
        {
            Destroy(gameObject);
        }
    }
}