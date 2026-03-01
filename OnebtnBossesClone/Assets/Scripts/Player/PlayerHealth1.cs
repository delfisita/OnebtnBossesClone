using UnityEngine;

public class PlayerHealth1 : MonoBehaviour, ITakeDamage
{
    public int maxLives = 3;
    private int currentLives;
    private GM gameManager;
    public AudioClip damagedSound;

    void Start()
    {
        currentLives = maxLives;

        gameManager = FindObjectOfType<GM>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyProjectile"))
        {
            TakeDamage(1);
            Destroy(collision.gameObject); 
        }
    }

    public void TakeDamage(int damage)
    {
        currentLives -= damage;
        Debug.Log("Vidas del jugador restantes: " + currentLives);
        CameraShake.Instance?.Shake(duration: 0.2f, magnitude: 0.15f);
        AudioManager.Instance.PlaySFX(damagedSound);
        if (currentLives <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        Debug.Log("Game Over: El jugador ha perdido todas las vidas.");
        gameManager.EndGame(false);
        Time.timeScale = 0;
    }
}