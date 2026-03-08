using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
   public void LoadMenu()
    {
        SceneManager.LoadScene("menu");
    }

    public void LoadLevelSelector()
    {
        SceneManager.LoadScene("LevelSelection");
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("level1");
    }
    public void LoadLevel2()
    {
        SceneManager.LoadScene("level2");
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
    }
}