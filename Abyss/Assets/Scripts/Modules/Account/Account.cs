using UnityEngine;

namespace Modules.Account
{
    public class Account
    {
        public AccountResources AccountSavedAccountResources { get; } = new AccountResources();
        public AccountResources OnShipAccountResources { get; } = new AccountResources();

        
        private bool _isPremium;
        private bool _haveProgress;
        private bool _isPlayerAlive;

        private string _playerShipName;


        public Account()
        {
            Load();
        }


        //Account parameters
        public void Save()
        {
            _haveProgress = true;
            PlayerPrefs.SetInt("PlayersCredits", AccountSavedAccountResources.GetCredits());
            PlayerPrefs.SetInt("PlayerMaterials", AccountSavedAccountResources.GetMaterials());
            PlayerPrefs.SetString("PlayerShip", _playerShipName);
            PlayerPrefs.SetInt("HaveProgress", 1);
        }

        public void SetPremium()
        {
            _isPremium = true;
        }
        
        private void Load()
        {
            if (PlayerPrefs.HasKey("HaveProgress"))
            {
                AccountSavedAccountResources.SetCredits(PlayerPrefs.GetInt("PlayersCredits"));
                AccountSavedAccountResources.SetMaterials(PlayerPrefs.GetInt("PlayerMaterials"));
                _playerShipName = PlayerPrefs.GetString("PlayerShip");
            }
            else
            {
                _playerShipName = "Falcon";
                Save();
            }
        }

        public void SetPlayerShipName(string name) => _playerShipName = name;

        public void Reset() => _haveProgress = false;

        
        //Ship
        public string GetPlayersShipName() => _playerShipName;


        //Resources actions

        public void AddResourcesToShip(int creditsValue, int materialsValue)
        {
            OnShipAccountResources.AddCredits(creditsValue);
            OnShipAccountResources.AddMaterials(materialsValue);
        }
        
        public void DepositToSave()
        {
            AccountSavedAccountResources.AddCredits(OnShipAccountResources.GetCredits());
            OnShipAccountResources.ResetCredits();
            AccountSavedAccountResources.AddMaterials(OnShipAccountResources.GetMaterials());
            OnShipAccountResources.ResetMaterials();
        }
        
        public void DepositQuadToSave()
        {
            AccountSavedAccountResources.AddCredits(OnShipAccountResources.GetCredits()/4);
            OnShipAccountResources.ResetCredits();
            AccountSavedAccountResources.AddMaterials(OnShipAccountResources.GetMaterials()/4);
            OnShipAccountResources.ResetMaterials();
        }

        public void TryRemoveCredits(int creditsValue, out bool success)
        {
            AccountSavedAccountResources.TryRemoveCredits(creditsValue, out success);
        }

        public bool HaveEnoughCredits(int value)
        {
            return AccountSavedAccountResources.GetCredits() > value;
        }
        
        public void TryRemoveMaterials(int materialsValue, out bool success)
        {
            AccountSavedAccountResources.TryRemoveMaterials(materialsValue, out success);
        }
        
        public bool HaveEnoughMaterials(int value)
        {
            return AccountSavedAccountResources.GetMaterials() > value;
        }
    }
}