using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public GameObject gameOverMenuUI;
   

    /*public void Retry()
    {
        gameOverMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }*/

    void Pause()
    {
        gameOverMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    /*public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }*/

    public void QuitGame()
    {
        Application.Quit();
    }
}
