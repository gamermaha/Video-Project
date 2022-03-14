using UnityEngine;
using UnityEngine.SceneManagement;

namespace Monster_Chase_Assets.Scripts
{
    public class MainMenuController : MonoBehaviour
    {
        [SerializeField] private AudioSource buttonClick;
        
        public void PlayGame()
        {
            int selectedCharacter =
                int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            
            GameManager.instance.CharIndex = selectedCharacter;
            buttonClick.Play();
            SceneManager.LoadScene("Gameplay");
        }
    }
}
