using UnityEngine;
using UnityEngine.UI;

namespace Objects.Gui.Components
{
    public class GSliderFiller : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        
        
        public void SetSliderValue(float percent) => _slider.value = percent;
    }
}