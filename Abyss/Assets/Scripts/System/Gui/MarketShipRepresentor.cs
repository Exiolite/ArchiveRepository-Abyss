using System.Gui.Components;
using System.LevelManaging;
using System.SpaceObjects.Dynamic;
using System.SpaceObjects.Static;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace System.Gui
{
    public class MarketShipRepresentor : MonoBehaviour
    {
        [SerializeField] private Image _shipIconHolder;
        [SerializeField] private TextMeshProUGUI _shipNameText;
        
        [SerializeField] private GValue _hitPointsGValueGUi;
        [SerializeField] private GValue _shieldGValue;
        [SerializeField] private GValue _dpsGValueText;
        [SerializeField] private GValue _depthGValueText;
        
        [SerializeField] private GValue _shipPriceCreditsText;
        [SerializeField] private GValue _shipPriceMaterialsText;

        private Ship _target;
        private ShipYard _targetShipYard;
        private PanelFlipper _parentPanel;
        

        private void Awake()
        {
            LevelEvent.SetShipYard.AddListener(SetShipYard);
        }

        public void SetRepresentor(Ship target, PanelFlipper parentPanel)
        {
            _target = target;
            _parentPanel = parentPanel;
            
            _shipIconHolder.sprite = _target.GetComponent<SpriteRenderer>().sprite;
            _shipNameText.text = _target.ObjName;

            _hitPointsGValueGUi.SetFloatText(_target.HealthStats.HitPoints.StatValue);
            _shieldGValue.SetFloatText(_target.HealthStats.Shield.StatValue);
            _dpsGValueText.SetFloatText(_target.GetShipDps());
            _depthGValueText.SetFloatText(_target.MaxDepth);
            
            _shipPriceCreditsText.SetIntText(_target.ShipPriceCredits);
            _shipPriceMaterialsText.SetIntText(_target.ShipPriceMaterials);
        }

        public void ButtonBuyClicked()
        {
            _targetShipYard.OnBuyShip(_target);
            _parentPanel.Deactivate();
        }



        private void SetShipYard(ShipYard shipYard)
        {
            _targetShipYard = shipYard;
        }
    }
}