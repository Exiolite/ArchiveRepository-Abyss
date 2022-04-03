using System.Core;
using System.Gui;
using UnityEngine;

namespace System.Navigation
{
    public class NavigationCircleCanvas : MonoBehaviour
    {
        [SerializeField] private UiResource _uiResource;
        [SerializeField] private PanelFlipper _panelFlipper;



        private void Awake()
        {
            _panelFlipper.Activate();
            GuiEvent.UpdateNavCircleResources.AddListener(UpdateText);
            _panelFlipper.Deactivate();
        }

        private void UpdateText()
        {
            _panelFlipper.ActivateWaitThenDisable();
        }
    }
}