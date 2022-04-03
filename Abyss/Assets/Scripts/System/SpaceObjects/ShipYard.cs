using System.Controller;
using System.Gui;
using UnityEngine;

namespace System.SpaceObjects
{
    public class ShipYard : SpaceObject
    {
        [SerializeField] private Transform _spawnPosition;

        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<Player>(out var player))
            {
                // TODO: Deposit credits to save 
                GuiEvent.UpdateNavCircleResources.Invoke();
            }
        }
    }
}