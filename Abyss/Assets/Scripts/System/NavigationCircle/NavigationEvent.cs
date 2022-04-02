using System.SpaceObjects;
using UnityEngine.Events;

namespace System.NavigationCircle
{
    public static class NavigationEvent
    {
        public static readonly AddArrow AddArrow = new AddArrow();
        public static readonly RemoveArrow RemoveArrow = new RemoveArrow();
    }
    public class AddArrow : UnityEvent <SpaceObject> {}
    public class RemoveArrow : UnityEvent <SpaceObject> {}
}