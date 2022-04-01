using Core;
using Events;
using Objects.Gui.Components;
using Objects.SpaceObjects;
using UnityEngine;

namespace Objects.NavigationCircle
{
    public class NavigationCircle : ObjectBehaviour
    {
        [SerializeField] private NavigationArrow _navigationArrow;

        [SerializeField] private GImageFiller _hitPoints;
        [SerializeField] private GImageFiller _shield;
        

        protected override void Initialize()
        {
            NavigationEvent.AddArrow.AddListener(AddArrow);
            LevelEvent.PlayerDeath.AddListener(DestroyItSelf);
        }

        protected override void Execute()
        {
            if (LevelManager.InstancedPlayer == null) return;
            transform.position = LevelManager.InstancedPlayer.transform.position;
            var playerShip = LevelManager.InstancedPlayer;
            
            _hitPoints.SetImageFill(playerShip.HealthStats.HitPoints.GetPercent());
            _shield.SetImageFill(playerShip.HealthStats.Shield.GetPercent());
        }


        private void AddArrow(SpaceObject target)
        {
            if (target == LevelManager.InstancedPlayer) return;
            var arrow = Instantiate(_navigationArrow, transform);
            arrow.SetTarget(target);
        }
        
        private void DestroyItSelf()
        {
            Destroy(gameObject);
        }
    }
}