using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Monster_Chase_Assets.Scripts
{
    public class GameManager : MonoBehaviour
    {
        [Header("GameObjects Imported")]
        [SerializeField] private GameObject[] players;

        [SerializeField] private GameplayUIController _uiController;
        
        public static GameManager instance;
        private int _charIndex;

        private UnityAction _playerDiedListener;

        public int CharIndex
        {
            get { return _charIndex; }
            set { _charIndex = value;  }
        }
        private void Awake()
        {
            _playerDiedListener = new UnityAction (PlayerDiedFunction);
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
                    Instantiate(players[CharIndex]).GetComponent<Player>();
                    EventManager.StartListening("PlayerDied", _playerDiedListener);
                }
            }
        }
        void PlayerDiedFunction()
        { 
            _uiController.GameOver();
            EventManager.StopListening("PlayerDied", _playerDiedListener);
        }
        
        
    }
}
