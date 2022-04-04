using Events;
using UnityEngine;

namespace MonoBehaviours.EventProvider
{
    public class OnMouseDownEventProvider : MonoBehaviour
    {
        private Transform _transform;

        private void Awake()
        {
            _transform = GetComponent<Transform>();
        }

        private void OnMouseDown()
        {
            EPlayerTargeting.OnTargetClicked.Invoke(_transform);
        }
    }
}