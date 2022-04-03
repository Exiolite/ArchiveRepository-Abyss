using System.SpaceObjects;
using UnityEngine.Events;

namespace System.LevelManaging
{
    public static class LevelEvent
    {
        public static readonly DestructAllSpaceObjects DestructAllSpaceObjects = new DestructAllSpaceObjects();
        public static readonly PlayerDeath PlayerDeath = new PlayerDeath();
        public static readonly RestartGame RestartGame = new RestartGame();
        public static readonly SetShipYard SetShipYard = new SetShipYard();
    }
    public class DestructAllSpaceObjects : UnityEvent {}
    public class PlayerDeath : UnityEvent {}
    public class RestartGame : UnityEvent {}
    
    public class SetShipYard : UnityEvent <ShipYard> {}
}