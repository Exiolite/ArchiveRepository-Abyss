using System.SpaceObjects;
using UnityEngine.Events;

namespace System.Navigation
{
    public static class ENavigationCircle
    {
        public static readonly AddNavigationCircleTarget AddNavigationCircleTarget = new AddNavigationCircleTarget();
        public static readonly RemoveNavigationCircleTarget RemoveNavigationCircleTarget = new RemoveNavigationCircleTarget();
        public static readonly SetNavigationCircleFollowTarget SetNavigationCircleFollowTarget = new SetNavigationCircleFollowTarget();
        public static readonly StartNavigationCircleFollowTarget StartNavigationCircleFollowTarget = new StartNavigationCircleFollowTarget();
        public static readonly StopNavigationCircleFollowTarget StopNavigationCircleFollowTarget = new StopNavigationCircleFollowTarget();
    }
    public class AddNavigationCircleTarget : UnityEvent <SpaceObject> {}
    public class RemoveNavigationCircleTarget : UnityEvent <SpaceObject> {}
    public class SetNavigationCircleFollowTarget : UnityEvent <Ship> {}
    public class StartNavigationCircleFollowTarget : UnityEvent {}
    public class StopNavigationCircleFollowTarget : UnityEvent {}
}