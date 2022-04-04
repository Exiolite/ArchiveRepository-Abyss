using Events;
using UnityEngine;

namespace MonoBehaviours
{
    public class Targeting : MonoBehaviour
    {
        private void OnMouseDown()
        {
            EPlayerTargeting.OnTargetClicked.Invoke(transform);
        }
    }
}