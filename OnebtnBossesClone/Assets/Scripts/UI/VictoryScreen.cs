using UnityEngine;
using UnityEngine.UI;

public class VictoryScreen : MonoBehaviour
{
    public GameObject victoryPanel;
    public Text totalTimeText;
    public Text bestTimeText;

    private GameTimer gameTimer;
    private float bestTime = Mathf.Infinity;

    void Start()
    {
        gameTimer = FindObjectOfType<GameTimer>();
        victoryPanel.SetActive(false); // Asegurarse de que el panel esté inactivo al inicio
    }

    public void ShowVictoryScreen()
    {
        victoryPanel.SetActive(true);
        totalTimeText.text = "Tiempo total: " + FormatTime(gameTimer.timeElapsed);

        if (gameTimer.timeElapsed < bestTime)
        {
            bestTime = gameTimer.timeElapsed;
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
