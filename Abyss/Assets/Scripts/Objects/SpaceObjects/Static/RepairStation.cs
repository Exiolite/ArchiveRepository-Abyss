using Events;
using Modules.HealthStats;
using UnityEngine;

namespace Objects.SpaceObjects.Static
{
    public class RepairStation : Station
    {
        [SerializeField] private int _repairTax = 1;
        
        private int _playerHitPointsDifference;
        private Stat _playerHitPoints;
        private int _creditsForRepair;
        
        
        
        public void OnRepair()
        {
            _playerHitPoints = LevelManager.InstancedPlayer.HealthStats.HitPoints;
            TryRemoveCredits(_creditsForRepair, out var success);
            if (success)
            {
                UpdateCreditsUi(_creditsForRepair);
                _playerHitPoints.Add(_playerHitPoints.GetDifference());
            }
        }
        
        
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (LevelManager.InstancedPlayer == null) return;
            if (other.gameObject != LevelManager.InstancedPlayer.gameObject) return;
            PlayersAccount.DepositToSave();
            GuiEvent.UpdateNavCircleResources.Invoke();

            _playerHitPointsDifference = ReadPlayerHitPointsDifference();
            _creditsForRepair = _playerHitPointsDifference * _repairTax;
            UpdateCreditsUi(_creditsForRepair);
        }
        
        protected override void Execute(){}
        
        
        
        private int ReadPlayerHitPointsDifference()
        {
            return LevelManager.InstancedPlayer.HealthStats.HitPoints.GetDifference();
        }
    }
}