using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScore : MonoBehaviour
{
    Text scoreTextUI;
    int score;

    public int Score
    {
        get
        {
            return this.score;
        }
        set
        {
            this.score = value;
            UpdateScoreTextUI(); // Actualiza el texto cuando se cambia la puntuación
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreTextUI = GetComponent<Text>();
        score = 0;
        UpdateScoreTextUI(); // Inicializa el texto al inicio del juego
    }

    // Método para actualizar el texto de la puntuación
    void UpdateScoreTextUI()
    {
        string scoreStr = string.Format("{0:00000000}", score);
        scoreTextUI.text = scoreStr;
    }

    // Método para incrementar la puntuación
    public void AddScore(int points)
    {
        Score += points;
    }
}
