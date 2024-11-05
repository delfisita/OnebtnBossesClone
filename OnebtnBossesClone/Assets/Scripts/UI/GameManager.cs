using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour

{

    public GameObject PlayButton;
    public GameObject Playerprefab;
    
    public GameObject GameOver;
    public GameObject scoreUItext;
    public enum GameManagerState
    {
        Opening,
        Gameplay,
        GameOver,
    }

    GameManagerState GMState;
   
    void Start()
    {
        GMState = GameManagerState.Opening;
       
        if (scoreUItext == null)
        {
            scoreUItext = GameObject.Find("ScoretextUI");
        }
    }

    void UpdateGameManagerState()
    {
        switch (GMState)
        {
            case GameManagerState.Opening:
                PlayButton.SetActive(true);
                GameOver.SetActive(false);
                break;
            case GameManagerState.Gameplay:
                scoreUItext.GetComponent<GameScore>().Score = 0;
                PlayButton.SetActive(false);
                Playerprefab.GetComponent<PlayerHealth>().Init();
              
                break;
            case GameManagerState.GameOver:
                
                GameOver.SetActive(true);
                Invoke("ChangeToOpeningState", 8f);
                break;
        }
    }
    public void SetGameManagerState(GameManagerState state)
    {
        {
            GMState = state;
            UpdateGameManagerState();

            if (state == GameManagerState.GameOver)
            {
                FindObjectOfType<VictoryScreen>().ShowVictoryScreen(); 
            }
        }        
    }

    public void StartGamePlay()
    {
        GMState = GameManagerState.Gameplay;
        UpdateGameManagerState();


    }
   
    public void ChangeToOpeningState()
    {
        SetGameManagerState(GameManagerState.Opening);
    }
    public void StopTimer()
    {
        Time.timeScale = 0;
    }
    public void RestartGame()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }





}

