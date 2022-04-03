using System.Globalization;
using System.SpaceObjects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace System.Gui
{
    public class StationGui : MonoBehaviour
    {
        [SerializeField] private SpaceObject _parentSpaceObject;
        
        [SerializeField] private Image _buyImage;
        [SerializeField] private TextMeshProUGUI _creditsPriceText;
        [SerializeField] private TextMeshProUGUI _materialsPriceText;

        private int _credits;
        private int _materials;
        



        private void Awake()
        {
            GetComponent<Canvas>().worldCamera = FindObjectOfType<UnityEngine.Camera>();
        }
        
        
        public void SetCredits(int credits)
        {
            _credits = credits;
            UpdateCreditsCounter();
        }
        
        public void SetMaterials(int materials)
        {
            _materials = materials;
            UpdateMaterialsCounter();
        }

        public void SetButtonColor(bool flag)
        {
            if (flag) _buyImage.color = Color.green;
            else _buyImage.color = Color.red;
        }

        private void UpdateCreditsCounter()
        {
            _creditsPriceText.text = _credits.ToString(CultureInfo.InvariantCulture);
        }

        private void UpdateMaterialsCounter()
        {
            _materialsPriceText.text = _materials.ToString(CultureInfo.InvariantCulture);
        }
    }
}