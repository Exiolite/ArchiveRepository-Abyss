using System.Core;
using UnityEngine;

namespace System.Navigation
{
    public class ArrowCollider : ObjectBehaviour
    {
        [SerializeField] private NavigationArrow _navigationArrow;


        private void OnMouseDown() => _navigationArrow.SetPlayersTarget();

        
        protected override void Initialize(){}
        protected override void Execute(){}
    }
}