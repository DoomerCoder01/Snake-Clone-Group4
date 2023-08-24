using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    /// <summary>
    /// Gives players access to a pause menu <Reference: Brackeys(2017).PAUSE MENU in Unity.Available at: https://www.youtube.com/watch?time_continue=696&v=JivuXdrIHK0&feature=emb_logo (Date acceseed: 05 June 2020).>
    /// </summary>
    public static bool GamePaused = false;

    public GameObject pauseMenuUI;
    public Gamerestart gamerestart; 
    // Update is called once per frame
    void Update()
    {
        gamerestart = GameObject.FindGameObjectWithTag("Player").GetComponent<Gamerestart>();
        if (Input.GetKeyDown(KeyCode.Escape)&& !gamerestart.Gameover)
        {
            if (GamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
    }

    void Pause()
    {

        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
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

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
