using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Monster_Chase_Assets.Scripts
{
    public class GameplayUIController : MonoBehaviour
    {
        [SerializeField] private AudioSource gameOver;

        public void RestartGame() => SceneManager.LoadScene("Gameplay");

        public void HomeButton() => SceneManager.LoadScene("MainMenu");
        
    }
}
