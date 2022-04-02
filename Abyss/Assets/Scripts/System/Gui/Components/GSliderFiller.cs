using UnityEngine;
using UnityEngine.UI;

namespace System.Gui.Components
{
    public class GSliderFiller : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        
        
        public void SetSliderValue(float percent) => _slider.value = percent;
    }
}