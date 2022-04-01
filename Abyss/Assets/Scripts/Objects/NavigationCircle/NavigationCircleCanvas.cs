using Core;
using Events;
using Objects.Gui;
using Objects.Gui.Components;
using UnityEngine;

namespace Objects.NavigationCircle
{
    public class NavigationCircleCanvas : ObjectBehaviour
    {
        [SerializeField] private ResourcesGui _resourcesGui;
        [SerializeField] private PanelFlipper _panelFlipper;

        

        protected override void Initialize()
        {
            _panelFlipper.Activate();
            GuiEvent.UpdateNavCircleResources.AddListener(UpdateText);
            _panelFlipper.Deactivate();
        }

        protected override void Execute()
        {
            
        }


        private void UpdateText()
        {
            _panelFlipper.ActivateWaitThenDisable();
            _resourcesGui.SetResources(PlayersAccount.OnShipAccountResources);
        }
    }
}