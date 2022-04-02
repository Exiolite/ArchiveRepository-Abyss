using Core;
using Objects.SpaceObjects.Dynamic;
using Utilities;

namespace Objects.Bot
{
    public class Bot : ObjectBehaviour
    {
        private Ship _botsShip;
        private bool _isAdgred;

        protected override void Initialize()
        {
            _botsShip = GetComponent<Ship>();
        }

        protected override void Execute()
        {
            if (_isAdgred || LevelManager.InstancedPlayer == null) return;
            if (RangeFinder.CalculateDistance(transform, LevelManager.InstancedPlayer) < 100)
            {
                _botsShip.SetTarget(LevelManager.InstancedPlayer);
                _isAdgred = true;
            }
        }
    }
}