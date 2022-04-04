using UnityEngine;
using UnityEngine.Events;

namespace Events
{
    public static class EPlayerTargeting
    {
        public static readonly OnTargetClicked OnTargetClicked = new OnTargetClicked();
    }
    public class OnTargetClicked : UnityEvent <Transform> {}
}