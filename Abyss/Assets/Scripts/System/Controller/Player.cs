using System.Camera;
using System.Navigation;
using System.PlayerInput.Swipe;
using System.SpaceObjects;
using UnityEngine;

namespace System.Controller
{
    public class Player : MonoBehaviour
    {
        private Ship _ship;

        protected void Awake()
        {
            _ship = GetComponent<Ship>();
            
            EPlayer.SetPlayersShipTarget.AddListener(_ship.SetTarget);
            EInputSwipe.SwipeUp.AddListener(_ship.WarpToTarget);
        }

        private void Start()
        {
            ENavigationCircle.SetNavigationCircleFollowTarget.Invoke(_ship);
            ENavigationCircle.StartNavigationCircleFollowTarget.Invoke();
            ECamera.SetTargetTransform.Invoke(transform);
            ECamera.StartNavigationCircleFollowTarget.Invoke();
        }
    }
}