using Objects.SpaceObjects;
using UnityEngine.Events;

namespace Events
{
    public static class NavigationEvent
    {
        public static readonly AddArrow AddArrow = new AddArrow();
        public static readonly RemoveArrow RemoveArrow = new RemoveArrow();
    }
    public class AddArrow : UnityEvent <SpaceObject> {}
    public class RemoveArrow : UnityEvent <SpaceObject> {}
}