using UnityEngine.Events;

namespace Events
{
    public static class BackGroundEvents
    {
        public static readonly DestroySpaceBackground DestroySpaceBackground = new DestroySpaceBackground();
    }
    public class DestroySpaceBackground : UnityEvent {}
}