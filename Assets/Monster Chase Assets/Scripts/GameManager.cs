using UnityEngine;
using UnityEngine.SceneManagement;

namespace Monster_Chase_Assets.Scripts
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;
        [SerializeField]
        private GameObject[] players;

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
            {
                Destroy(gameObject);
            }
        }

        private void OnDisable()
        { 
            SceneManager.sceneLoaded -= OnLevelFinishedLoading;
        }

        private void OnEnable()
        {
            SceneManager.sceneLoaded += OnLevelFinishedLoading;
        }

        void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
        {
            if (scene.name == "Gameplay")
            {
                if (CharIndex == 0 || CharIndex == 1 )
                {
                    Instantiate(players[CharIndex]);
                    
                }
                
                
            }
        }
    
    
    }
}
