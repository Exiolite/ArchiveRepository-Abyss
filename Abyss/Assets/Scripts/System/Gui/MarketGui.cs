using System.Core;
using UnityEngine;

namespace System.Gui
{
    public class MarketGui : ObjectBehaviour
    {
        [SerializeField] private MarketShipRepresentor _shipRepresentor;
        
        [SerializeField] private ResourcesGui _resourcesGui;

        [SerializeField] private GameObject _marketContent;
        
        private PanelFlipper _marketFlipper;

        

        protected override void Initialize()
        {
            _marketFlipper = GetComponent<PanelFlipper>();
            
            foreach (var marketShip in LevelManager.DataBase.MarketShips)
            {
                var shipRepresentor = Instantiate(_shipRepresentor, _marketContent.transform);
                shipRepresentor.SetRepresentor(marketShip, _marketFlipper);
            }

            GuiEvent.ShowMarket.AddListener(SetPanelActive);
            _marketFlipper.Deactivate();
        }

        protected override void Execute()
        {
        }


        private void SetPanelActive()
        {
            _marketFlipper.Activate();
            _resourcesGui.SetResources(PlayersAccount.AccountSavedAccountResources);
        }
    }
}