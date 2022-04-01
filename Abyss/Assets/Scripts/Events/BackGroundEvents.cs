using UnityEngine.Events;

namespace Events
{
    public static class BackGroundEvents
    {
        public static readonly DestroyBackground DestroyBackground = new DestroyBackground();
    }
    public class DestroyBackground : UnityEvent {}
}