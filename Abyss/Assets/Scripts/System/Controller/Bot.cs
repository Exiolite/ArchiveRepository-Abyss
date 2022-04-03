using System.SpaceObjects;
using UnityEngine;
using Utilities;

namespace System.Controller
{
    public class Bot : MonoBehaviour
    {
        private Ship _botsShip;
        private Ship _playerShip;
        private bool _isBotAttackPlayer;

        
        protected void Awake()
        {
            _botsShip = GetComponent<Ship>();
            
            EPlayer.SetPlayersShipTarget.AddListener(SetPlayersShipTarget);
            EBot.StartBotAttackPlayer.AddListener(StartBotAttackPlayer);
            EBot.StopBotAttackPlayer.AddListener(StopBotAttackPlayer);
        }
        
        private void Update()
        {
            if (!_isBotAttackPlayer) return;
            if (!(RangeFinder.CalculateDistance(transform, _playerShip) < 100)) return;
            _botsShip.SetTarget(_playerShip);
        }
        
        
        private void SetPlayersShipTarget(SpaceObject target)
        {
            _playerShip = (Ship) target;
        }
        
        private void StartBotAttackPlayer()
        {
            _isBotAttackPlayer = true;
            _botsShip.SetTarget(_playerShip);
        }
        
        private void StopBotAttackPlayer()
        {
            _isBotAttackPlayer = false;
            _botsShip.SetTarget(null);
        }
    }
}