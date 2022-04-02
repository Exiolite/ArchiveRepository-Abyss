using System.Controller;
using System.Core;
using System.Movements;
using System.SpaceObjects;
using System.SpaceObjects.Dynamic;
using System.SpaceObjects.Static;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

namespace System.Navigation
{
    public class NavigationArrow : ObjectBehaviour
    {
        //Arrow
        [SerializeField] private GameObject _toTargetSpring;
        [SerializeField] private GameObject _canvasPivot;
        [SerializeField] private ArrowCollider _arrowCollider;
        //TargetCanvas
        [SerializeField] private TextMeshProUGUI _objectName;
        [SerializeField] private Image _hitPoints;
        [SerializeField] private Image _shield;
        
        [SerializeField, HideInInspector] private Movement _movement;
        
        public SpaceObject Target { get; private set; }

        
        
        public void SetTarget(SpaceObject target)
        {
            Target = target;
            _objectName.text = Target.ObjName;
            if (target is Ship) _objectName.color = Color.red;
            else if (target is Station) _objectName.color = Color.white;
            else if (target is Abyss) _objectName.color = Color.magenta;
            else if (target is Container) _objectName.color = Color.yellow;
            else _objectName.color = Color.white;
        }

        public void SetPlayersTarget()
        {
            EPlayer.SetPlayersShipTarget.Invoke(Target);
        }
        
        
        
        protected override void Initialize()
        {
            ENavigationCircle.RemoveNavigationCircleTarget.AddListener(DestroyItSelf);
        }

        protected override void Execute()
        {
            if (Target == null) return;
            _movement.HardRotateToTarget(transform, Target.transform);
            UpdateArrow();
        }

        
        
        private void UpdateArrow()
        {
            UpdateTargetStats();
            UpdateSpring();
        }

        private void UpdateTargetStats()
        {
            if (Target.GetType() == typeof(Ship))
            {
                var targetShip = (Ship) Target;
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
            _canvasPivot.transform.eulerAngles = new Vector3(0,0,0);
            var distanceToTarget = RangeFinder.CalculateDistance(transform, Target);
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
            if (Target == target)
            {
                ENavigationCircle.RemoveNavigationCircleTarget.RemoveListener(DestroyItSelf);
                Destroy(gameObject);
            }
        }
    }
}