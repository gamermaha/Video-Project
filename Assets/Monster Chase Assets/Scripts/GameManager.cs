﻿using UnityEngine;
using UnityEngine.SceneManagement;

namespace Monster_Chase_Assets.Scripts
{
    public class GameManager : MonoBehaviour
    {
        [Header("GameObjects Imported")]
        [SerializeField] private GameObject[] players;

        [SerializeField] private GameplayUIController _uiController;
        
        public static GameManager instance;
        private Player _spawnedPlayer;
        private int _charIndex;

        public int CharIndex
        {
            get { return _charIndex; }
            set { _charIndex = value;  }
        }
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
                Destroy(gameObject);
            
        }
        private void OnEnable()
        {
            SceneManager.sceneLoaded += OnLevelFinishedLoading;
        }
        private void OnDisable()
        { 
            SceneManager.sceneLoaded -= OnLevelFinishedLoading;
        }

        void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
        {
            if (scene.name == "Gameplay")
            {
                if (CharIndex == 0 || CharIndex == 1 )
                {
                    AudioManager.instance.buttonClick.Play();
                    _spawnedPlayer = Instantiate(players[CharIndex]).GetComponent<Player>();
                    _spawnedPlayer.PlayerDiedInfo += PlayerDiedListener;
                }
            }
        }
        void PlayerDiedListener(bool alive)
        {
            _uiController.GameOver();
            _spawnedPlayer.PlayerDiedInfo -= PlayerDiedListener;
        }
        
        
    }
}
