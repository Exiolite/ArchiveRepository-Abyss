using System.Controller;
using System.Gui;
using UnityEngine;

namespace System.SpaceObjects
{
    public class RepairStation : SpaceObject
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<Player>(out var player))
            {
                // TODO: Deposit credits to save 
            }
        }
    }
}