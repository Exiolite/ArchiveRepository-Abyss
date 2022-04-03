using System.Controller;
using System.Gui;
using UnityEngine;

namespace System.SpaceObjects
{
    public class Container : SpaceObject
    {
        [SerializeField] private int _credits;
        [SerializeField] private int _materials;


        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<Player>(out var player))
            {
                // TODO: Deposit credits to save 
            }
        }
    }
}