using System.Collections;
using UnityEngine;

namespace System.Gui
{
    public class PanelFlipper : MonoBehaviour
    {
        [Tooltip("Assign panel for turning Off/On. To flip/flop panel - assign Methods of this script in button")]
        [SerializeField] private GameObject _panel;

        private bool _isPanelActive;


        public void FlipPanelActive()
        {
            _isPanelActive = !_isPanelActive;
            _panel.SetActive(_isPanelActive);
        }

        public void ActivateWaitThenDisable()
        {
            Activate();
            
            StartCoroutine(DisableResourcesPanel());
        }
        
        public void ActivateThenDisable()
        {
            Activate();
            Deactivate();
        }

        public void Activate()
        {
            _isPanelActive = true;
            _panel.SetActive(_isPanelActive);
        }
        
        public void Deactivate()
        {
            _isPanelActive = false;
            _panel.SetActive(_isPanelActive);
        }
        
        

        private IEnumerator DisableResourcesPanel()
        {
            yield return new WaitForSeconds(2);
            Deactivate();
        }
    }
}