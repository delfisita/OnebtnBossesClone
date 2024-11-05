using UnityEngine;
using UnityEngine.UI;

public class VictoryScreen : MonoBehaviour
{
    public GameObject victoryPanel; // Panel de victoria
    public Text totalTimeText; // Texto para el tiempo total
    public Text bestTimeText; // Texto para el mejor tiempo

    private GameTimer gameTimer; // Referencia al GameTimer
    private float bestTime = Mathf.Infinity; // Inicializar el mejor tiempo como infinito

    void Start()
    {
        gameTimer = FindObjectOfType<GameTimer>(); // Obtener el GameTimer
    }

    public void ShowVictoryScreen()
    {
        victoryPanel.SetActive(true); // Activar el panel de victoria
        totalTimeText.text = "Tiempo total: " + FormatTime(gameTimer.timeElapsed); // Mostrar el tiempo total

        // Comparar con el mejor tiempo
        if (gameTimer.timeElapsed < bestTime)
        {
            bestTime = gameTimer.timeElapsed; // Actualizar mejor tiempo
            bestTimeText.text = "¡Nuevo mejor tiempo!";
        }
        else
        {
            bestTimeText.text = "Mejor tiempo: " + FormatTime(bestTime);
        }
    }

    string FormatTime(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
