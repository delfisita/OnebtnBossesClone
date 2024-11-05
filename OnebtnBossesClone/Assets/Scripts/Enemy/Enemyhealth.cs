using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    GameObject scoreUIText;
    public float health = 100f;
    public GameObject gameManager; 
    
  

    void Start()
    {
        scoreUIText = GameObject.FindGameObjectWithTag("ScoretextUI");

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            scoreUIText.GetComponent<GameScore>().Score += 100;
            Destroy(collision.gameObject);
        }
    }

  
    void Die()
    {
        Debug.Log("Enemigo derrotado");
        // Puedes agregar más lógica aquí, como desactivar o destruir el enemigo
        gameObject.SetActive(false); // Desactivar el enemigo
        // o usa Destroy(gameObject); para eliminarlo completamente
    }
}
