using System.SpaceObjects;
using UnityEngine.Events;

namespace System.Controller
{
    public static class EPlayer
    {
        public static readonly SetPlayersShipTarget SetPlayersShipTarget = new SetPlayersShipTarget();
    }
    public class SetPlayersShipTarget : UnityEvent <SpaceObject> {}
}