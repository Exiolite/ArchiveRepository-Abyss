using Core.LevelManaging;
using Events;
using Modules.Account;
using UnityEngine;
using UnityEngine.Advertisements;

namespace Core
{
    public class Core : MonoBehaviour
    {
        #region Singleton

        private static Core _instance;

        public static Core Instance => _instance;

        void Awake()
        {
            if (_instance == null)
                _instance = this;
            else if (_instance != this)
            {
                Destroy(gameObject);
                return;
            }
            DontDestroyOnLoad(gameObject);
            FirstInitialization();
        }

       
        #endregion

        public Account PlayersAccount => _playersAccount;
        public LevelManager LevelManager => _levelManager;
        
        
        private Account _playersAccount;
        private LevelManager _levelManager;
        
        private Factory _factory;


        private void FirstInitialization()
        {
            Advertisement.Initialize("4012389");
            InitializeCoreModules();
            GameStart();
        }

        private void InitializeCoreModules()
        {
            _factory = gameObject.AddComponent<Factory>();
            gameObject.AddComponent<SwipeInput>();
            _playersAccount = new Account();
            _levelManager = new LevelManager(_factory);
        }

        private void GameStart()
        {
            LevelEvent.RestartGame.AddListener(_levelManager.ResetLevels);
            _levelManager.ManageLevelCreation();
        }

        private void OnApplicationPause(bool pauseStatus)
        {
            _playersAccount.Save();
        }

        private void OnApplicationQuit()
        {
            _playersAccount.Save();
        }
    }
}