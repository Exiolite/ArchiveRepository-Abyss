using UnityEngine.Events;

namespace Objects.SpaceBackground
{
    public static class ESpaceBackground
    {
        public static readonly InstantiateSpaceBackground InstantiateSpaceBackground = new InstantiateSpaceBackground();
        public static readonly RandomizeSpaceBackground RandomizeSpaceBackground = new RandomizeSpaceBackground();
    }
    public class InstantiateSpaceBackground : UnityEvent {}
    public class RandomizeSpaceBackground : UnityEvent {}
}