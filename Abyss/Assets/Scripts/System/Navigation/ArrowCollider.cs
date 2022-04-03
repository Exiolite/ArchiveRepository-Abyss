using UnityEngine;

namespace System.Navigation
{
    public class ArrowCollider : MonoBehaviour
    {
        [SerializeField] private NavigationArrow _navigationArrow;
        
        private void OnMouseDown() => _navigationArrow.SetPlayersTarget();
    }
}