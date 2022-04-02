using System.Core;
using System.LevelManaging;
using UnityEngine;
using UnityEngine.Advertisements;

namespace System.Gui
{
    public class DeathScreen : ObjectBehaviour
    {
        [SerializeField] private ResourcesGui _resourcesGui;

        private PanelFlipper _deathPanelFlipper;


        public void ButtonWatchAd()
        {
            if (Advertisement.IsReady())
                Advertisement.Show();
            
            PlayersAccount.DepositQuadToSave();
            LevelEvent.RestartGame.Invoke();
            PlayersAccount.Reset();
            _deathPanelFlipper.Deactivate();
        }

        public void ButtonRestart()
        {
            PlayersAccount.Reset();
            LevelEvent.RestartGame.Invoke();
            _deathPanelFlipper.Deactivate();
        }


        protected override void Initialize()
        {
            _deathPanelFlipper = GetComponent<PanelFlipper>();
            LevelEvent.PlayerDeath.AddListener(SetDeathPanelActive);
            _deathPanelFlipper.Deactivate();
        }

        protected override void Execute()
        {
        }


        private void SetDeathPanelActive()
        {
            _deathPanelFlipper.Activate();
            _resourcesGui.SetDividedResources(PlayersAccount.OnShipAccountResources);
        }
    }
}