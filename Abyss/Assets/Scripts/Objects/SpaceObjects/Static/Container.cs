using Events;
using UnityEngine;

namespace Objects.SpaceObjects.Static
{
    public class Container : SpaceObject
    {
        [SerializeField] private int _credits;
        [SerializeField] private int _materials;


        private void OnTriggerEnter2D(Collider2D other)
        {
            if (LevelManager.InstancedPlayer == null) return;
            if (other.gameObject != LevelManager.InstancedPlayer.gameObject) return;
            PlayersAccount.AddResourcesToShip(Random.Range(0, _credits), Random.Range(0, _materials));
            GuiEvent.UpdateNavCircleResources.Invoke();
            DestroyItSelf();
        }

        protected override void Execute()
        {
           
        }
    }
}