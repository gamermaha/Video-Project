using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void playGame()
    {
        int selectedCharacter =
            int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

        Warrior.name = "Warior";
        Warrior.power = 100;

        GameManager.instance.CharIndex = selectedCharacter;
        SceneManager.LoadScene("Gameplay");
    }
}
