using UnityEngine;

namespace System.SpaceObjects.Static
{
    public class Abyss : SpaceObject
    {
        protected override void Execute()
        {
            var tTransform = transform;
            tTransform.eulerAngles = new Vector3(0,0, tTransform.eulerAngles.z - (Time.deltaTime * 8));
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject == LevelManager.InstancedPlayer.gameObject)
            {
                LevelManager.CreateNextLevel();
            }
        }
    }
}