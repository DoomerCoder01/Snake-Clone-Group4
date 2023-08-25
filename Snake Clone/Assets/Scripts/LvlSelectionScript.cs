using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LvlSelectionScript : MonoBehaviour
{
    public void SnakeEasyLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SnakeMediumLevel()
    {
       SceneManager.LoadScene("SnakeMediumLevel");
    }

    public void SnakeHardLevel()
    {
        SceneManager.LoadScene("SnakeHardLevel");
    }
}
