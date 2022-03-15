using UnityEngine;

namespace Monster_Chase_Assets.Scripts
{
    public class MetaData : MonoBehaviour
    {
        public static MetaData Instance;
        public GameConfig scriptableInstance;
        public void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this);
            }
            else
                Destroy(this);
        }
   
    }
}
