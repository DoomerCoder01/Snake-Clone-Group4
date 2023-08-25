using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// Activating the buttons on the main menu screen<Reference: Brackeys(2017). START MENU in Unity. Available at: https://www.youtube.com/watch?v=zc8ac_qUXQY (Date accesed: 05 June 2020).>
    /// </summary>
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void HowToPlay()
    {
        SceneManager.LoadScene("HowToPlay");
    }

     public void Hardlevel()
    {
       SceneManager.LoadScene("Snake Hard Level");
        Time.timeScale = 1f;
    }
    public void MediumLevel()
    {
        SceneManager.LoadScene("Snake Medium  Level");
        Time.timeScale = 1f;
    }
    public void EasyLevel()
    {
        SceneManager.LoadScene("Snake");
        Time.timeScale = 1f;
    }
}
