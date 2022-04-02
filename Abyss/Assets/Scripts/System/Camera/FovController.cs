using System.Gui;
using UnityEngine;

namespace System.Camera
{
    public class FovController : MonoBehaviour
    {
        [SerializeField] private GameObject _cameraHolder;

        [Header("Camera Parameters")]
        [SerializeField] private float _minCameraDistance = -80;
        [SerializeField] private float _maxCameraDistance = -400;
        
        

        private void Awake()
        {
            GuiEvent.OnZoomSliderChanged.AddListener(OnZoomSliderEvent);
        }


        private void OnZoomSliderEvent(float value)
        {
            var cameraPosZ = Mathf.Clamp((value * _maxCameraDistance), _maxCameraDistance, _minCameraDistance);
            _cameraHolder.transform.localPosition = new Vector3(0,0,cameraPosZ);
        }
        
    }
}