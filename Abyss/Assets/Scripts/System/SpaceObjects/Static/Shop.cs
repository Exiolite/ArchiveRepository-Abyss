using System.Gui;
using UnityEngine;

namespace System.SpaceObjects.Static
{
    public class Shop : Station
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (LevelManager.InstancedPlayer == null) return;
            if (other.gameObject != LevelManager.InstancedPlayer.gameObject) return;
            PlayersAccount.DepositToSave();
            GuiEvent.UpdateNavCircleResources.Invoke();
        }
        
        protected override void Execute()
        {
            
        }
    }
}