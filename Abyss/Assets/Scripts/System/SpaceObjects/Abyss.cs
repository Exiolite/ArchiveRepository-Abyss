using System.Controller;
using System.Gui;
using UnityEngine;

namespace System.SpaceObjects
{
    public class Abyss : SpaceObject
    {
        private void Update()
        {
            var tTransform = transform;
            tTransform.eulerAngles = new Vector3(0,0, tTransform.eulerAngles.z - (Time.deltaTime * 8));
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<Player>(out var player))
            {
                // TODO: Teleport player to another level
            }
        }
    }
}