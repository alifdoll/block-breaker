using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        int currentSceneIdx = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIdx + 1);
    }


    public void LoadStart()
    {
        SceneManager.LoadScene(0);
        if (SceneManager.GetActiveScene().buildIndex == 3 || SceneManager.GetActiveScene().buildIndex == 0)
        {
            FindObjectOfType<GameSession>().ResetGame();
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

}
