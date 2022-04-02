using UnityEngine;
using UnityEngine.Events;

namespace System.Camera
{
    public static class ECamera
    {
        public static readonly SetTargetTransform SetTargetTransform = new SetTargetTransform();
        public static readonly ResetTargetTransform ResetTargetTransform = new ResetTargetTransform();
        public static readonly StartNavigationCircleFollowTarget StartNavigationCircleFollowTarget = new StartNavigationCircleFollowTarget();
        public static readonly StopFollowTarget StopFollowTarget = new StopFollowTarget();
    }
    public class SetTargetTransform : UnityEvent <Transform> {}
    public class ResetTargetTransform : UnityEvent {}
    public class StartNavigationCircleFollowTarget : UnityEvent {}
    public class StopFollowTarget : UnityEvent {}
}