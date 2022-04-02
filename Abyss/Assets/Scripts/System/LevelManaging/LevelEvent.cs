using System.SpaceObjects.Dynamic;
using System.SpaceObjects.Static;
using UnityEngine.Events;

namespace System.LevelManaging
{
    public static class LevelEvent
    {
        public static readonly DestroyAllExcludePlayer DestroyAllExcludePlayer = new DestroyAllExcludePlayer();
        public static readonly PlayerDeath PlayerDeath = new PlayerDeath();
        public static readonly RestartGame RestartGame = new RestartGame();
        public static readonly SetShipYard SetShipYard = new SetShipYard();
    }
    public class DestroyAllExcludePlayer : UnityEvent <Ship> {}
    public class PlayerDeath : UnityEvent {}
    public class RestartGame : UnityEvent {}
    
    public class SetShipYard : UnityEvent <ShipYard> {}
}