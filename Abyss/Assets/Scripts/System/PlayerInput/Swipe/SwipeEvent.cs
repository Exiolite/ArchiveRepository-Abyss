using UnityEngine.Events;

namespace System.PlayerInput.Swipe
{
    public static class SwipeEvent
    {
        public static readonly SwipedUp SwipedUp = new SwipedUp();
    }
    public class SwipedUp : UnityEvent {}
}