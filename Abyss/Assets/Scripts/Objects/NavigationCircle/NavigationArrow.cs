using Core;
using Events;
using Modules.Movements;
using Objects.SpaceObjects;
using Objects.SpaceObjects.Dynamic;
using Objects.SpaceObjects.Static;
using Statics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Objects.NavigationCircle
{
    public class NavigationArrow : ObjectBehaviour
    {
        //Arrow
        [SerializeField] private GameObject _toTargetSpring;
        [SerializeField] private GameObject _canvasRotator;
        [SerializeField] private ArrowCollider _arrowCollider;
        //TargetCanvas
        [SerializeField] private TextMeshProUGUI _objectName;
        [SerializeField] private Image _hitPoints;
        [SerializeField] private Image _shield;
        
        [SerializeField, HideInInspector] private Movement _movement;
        
        private SpaceObject _target;

        
        
        public void SetTarget(SpaceObject target)
        {
            _target = target;
            _objectName.text = _target.ObjName;
            if (target is Ship) _objectName.color = Color.red;
            else if (target is Station) _objectName.color = Color.white;
            else if (target is Abyss) _objectName.color = Color.magenta;
            else if (target is Container) _objectName.color = Color.yellow;
            else _objectName.color = Color.white;
        }

        public void SetPlayersTarget()
        {
            LevelManager.InstancedPlayer.SetTarget(_target);
        }
        
        
        
        protected override void Initialize()
        {
            NavigationEvent.RemoveArrow.AddListener(DestroyItSelf);
        }

        protected override void Execute()
        {
            if (_target == null) return;
            _movement.HardRotateToTarget(transform, _target.transform);
            UpdateArrow();
        }

        
        
        private void UpdateArrow()
        {
            UpdateTargetStats();
            UpdateSpring();
        }

        private void UpdateTargetStats()
        {
            if (_target.GetType() == typeof(Ship))
            {
                var targetShip = (Ship) _target;
                _shield.fillAmount = targetShip.HealthStats.Shield.GetPercent();
                _hitPoints.fillAmount = targetShip.HealthStats.HitPoints.GetPercent();
            }
            else
            {
                _shield.fillAmount = 0;
                _hitPoints.fillAmount = 0;
            }
        }

        private void UpdateSpring()
        {
            _canvasRotator.transform.eulerAngles = new Vector3(0,0,0);
            var distanceToTarget = RangeFinder.CalculateDistance(transform, _target);
            if (distanceToTarget < 17.5f)
            {
                _toTargetSpring.transform.localPosition = new Vector3(distanceToTarget, 0,0);
                _arrowCollider.transform.localPosition = new Vector3(0,4,0);
            }
            else
            {
                _toTargetSpring.transform.localPosition = new Vector3(17.5f, 0,0);
                _arrowCollider.transform.localPosition = new Vector3(0,0,0);
            }
        }

        private void DestroyItSelf(SpaceObject target)
        {
            if (_target == target)
            {
                NavigationEvent.RemoveArrow.RemoveListener(DestroyItSelf);
                Destroy(gameObject);
            }
        }
    }
}