using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100f;
    private VictoryScreen victoryScreen;
    public Enemyshoot enemyshoot;
   public BossEnemy bossEnemy;

    void Start()
    {
        StartCoroutine(switchshoot());
        victoryScreen = FindObjectOfType<VictoryScreen>(); // Obtener la referencia de VictoryScreen
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(25f);
            Destroy(collision.gameObject);
        }
    }

    void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    public IEnumerator switchshoot()
    {
        while (true)
        {
            enemyshoot.enabled = true; 
            bossEnemy.enabled = false;
            yield return new WaitForSeconds(2f);
            enemyshoot.enabled = false;
            bossEnemy.enabled = true;
            yield return new WaitForSeconds(2f);


        }
    }
    void Die()
    {
        victoryScreen.ShowVictoryScreen();
        Destroy(gameObject);
    }
}
