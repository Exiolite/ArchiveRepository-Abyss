using System.LevelManaging;
using UnityEngine;

namespace System.Core
{
    public abstract class ObjectBehaviour : MonoBehaviour
    {
        protected Account.Account PlayersAccount;
        protected LevelManager LevelManager;

        

        private void Start()
        {
            LevelManager = Core.Instance.LevelManager;
            PlayersAccount = Core.Instance.PlayersAccount;
            Initialize();
        }

        private void Update()
        {
            Execute();
        }

        protected abstract void Initialize();
        protected abstract void Execute();
    }
}