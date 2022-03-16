using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Monster_Chase_Assets.Scripts
{
    public class GameplayUIController : MonoBehaviour
    {
        public void RestartGame() => SceneManager.LoadScene("Gameplay");
        public void HomeButton() => SceneManager.LoadScene("MainMenu");
        public void GameOver()
        {
            AudioManager.instance.gameOver.Play();
            SceneManager.LoadScene("GameOver");
        }
        
    }
}
