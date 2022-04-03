using System.Controller;
using System.LevelManaging;
using System.Navigation;
using UnityEngine;

namespace System.SpaceObjects
{
    public abstract class SpaceObject : MonoBehaviour
    {
        public string ObjName => _objName;

        [SerializeField] private string _objName;


        private bool _isPlayer;
        

        private void Awake()
        {
            _isPlayer = gameObject.TryGetComponent<Player>(out var player);
            if (_isPlayer) return;

            LevelEvent.DestructAllSpaceObjects.AddListener(DestroyObject);
        }

        private void Start()
        {
            ENavigationCircle.AddNavigationCircleTarget.Invoke(this);
        }

        private void OnMouseDown()
        {
            EPlayer.SetPlayersShipTarget.Invoke(this);
        }
        

        private void DestroyObject()
        {
            if (_isPlayer) return;
            ENavigationCircle.RemoveNavigationCircleTarget.Invoke(this);
            Destroy(gameObject);
        }
    }
}