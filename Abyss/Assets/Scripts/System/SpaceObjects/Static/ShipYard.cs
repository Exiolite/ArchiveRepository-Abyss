using System.Gui;
using System.LevelManaging;
using System.SpaceObjects.Dynamic;
using UnityEngine;

namespace System.SpaceObjects.Static
{
    public class ShipYard : Station
    {
        [SerializeField] private Transform _spawnPosition;



        public void ButtonShowMarketUi()
        {
            GuiEvent.ShowMarket.Invoke();
            LevelEvent.SetShipYard.Invoke(this);
        }
        
        public void OnBuyShip(Ship target) // GUI Button Event.
        {
            TryRemoveCredits(target.ShipPriceCredits , out var successRemovedCredits);
            TryRemoveMaterials(target.ShipPriceMaterials, out var successRemovedMaterials);
            if (successRemovedCredits && successRemovedMaterials)
            {
                SwitchPlayerToShip(target);
            }
        }
        
        
        protected override void Execute()
        {
            
        }



        private void SwitchPlayerToShip(Ship target)
        {
            var newShip = LevelManager.SpawnShipOnShipYard(transform, target);
            LevelManager.SetPlayersShip(newShip);
            PlayersAccount.SetPlayerShipName(newShip.ObjName);
        }

        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (LevelManager.InstancedPlayer == null) return;
            if (other.gameObject != LevelManager.InstancedPlayer.gameObject) return;
            PlayersAccount.DepositToSave();
            GuiEvent.UpdateNavCircleResources.Invoke();
        }
    }
}