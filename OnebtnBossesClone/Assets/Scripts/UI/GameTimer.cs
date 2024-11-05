using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public float timeElapsed;
    public Text timerText; 

    void Start()
    {
        timeElapsed = 0f; 
    }

    void Update()
    {
        if (Time.timeScale != 0) 
        {
            timeElapsed += Time.deltaTime; 
            UpdateTimerText(); 
        }
    }

    void UpdateTimerText()
    {
        
        float minutes = Mathf.FloorToInt(timeElapsed / 60);
        float seconds = Mathf.FloorToInt(timeElapsed % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
