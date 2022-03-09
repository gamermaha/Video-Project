using UnityEngine;
using UnityEngine.SceneManagement;

namespace Monster_Chase_Assets.Scripts
{
    public class MainMenuController : MonoBehaviour
    {
        public void PlayGame()
        {
            int selectedCharacter =
                int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
        
            
            GameManager.instance.CharIndex = selectedCharacter;
            SceneManager.LoadScene("Gameplay");
        }
    }
}
