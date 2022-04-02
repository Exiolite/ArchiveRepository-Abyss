using System.Core;
using UnityEngine;
using UnityEngine.UI;

namespace System.Gui
{
    public class GameUi : ObjectBehaviour
    {
        [SerializeField] private ResourcesGui _resourcesGui;
        [SerializeField] private PanelFlipper _resourcesFlipper;
        


        public void OnZoomSliderChanged(Slider slider) => GuiEvent.OnZoomSliderChanged.Invoke(slider.value);

        

        protected override void Initialize()
        {
            _resourcesFlipper.ActivateThenDisable();
            GuiEvent.UpdateNavCircleResources.AddListener(UpdateResources);
        }

        protected override void Execute(){}

        
        
        private void UpdateResources()
        {
            _resourcesFlipper.ActivateWaitThenDisable();
            _resourcesGui.SetResources(PlayersAccount.AccountSavedAccountResources);
        }
    }
}