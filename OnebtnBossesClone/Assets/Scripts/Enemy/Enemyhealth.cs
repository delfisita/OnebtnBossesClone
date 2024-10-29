using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyhealth : MonoBehaviour
{
    public float health = 100f; 

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet")) 
        {
            TakeDamage(20f);
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

    void Die()
    {
        
        Debug.Log("Enemigo derrotado");
        Time.timeScale = 0; 
}
    }