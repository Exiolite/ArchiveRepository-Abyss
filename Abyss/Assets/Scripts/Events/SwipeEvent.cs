using UnityEngine.Events;

namespace Events
{
    public static class SwipeEvent
    {
        public static readonly SwipedUp SwipedUp = new SwipedUp();
    }
    public class SwipedUp : UnityEvent {}
}