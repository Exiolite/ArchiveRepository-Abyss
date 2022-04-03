using UnityEngine.Events;

namespace System.PlayerInput.Swipe
{
    public static class EInputSwipe
    {
        public static readonly SwipedUp SwipeUp = new SwipedUp();
    }
    public class SwipedUp : UnityEvent {}
}