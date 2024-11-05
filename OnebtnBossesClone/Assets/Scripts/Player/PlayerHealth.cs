using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    

    public GameObject GameManager1;
   

    public Text LivesUIText;
    const int MaxLives = 3;
    int lives;
    
    public void Init()
    {
       
        lives = MaxLives;
        LivesUIText.text = lives.ToString();

        transform.position = new Vector2(0, 0);
        gameObject.SetActive(true);
    }
    void Start()
    {
      
    }


    void Update()
    {
       
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EnemyBullet")
        {
            Debug.Log("Colisión con bala detectada");

            // Verifica antes de restar vidas
            if (lives > 0)
            {
                lives--; // Resta vidas solo si hay más de 0
                Debug.Log("Vidas restantes: " + lives);

                if (LivesUIText != null)
                {
                    LivesUIText.text = lives.ToString();
                }

                // Si las vidas llegan a 0, desactiva el jugador
                if (lives <= 0)
                {
                    Debug.Log("Jugador muerto. Vidas: " + lives);
                    if (GameManager1 != null)
                    {
                        GameManager1.GetComponent<GameManager>().SetGameManagerState(GameManager.GameManagerState.GameOver);
                    }

                    gameObject.SetActive(false); // Desactiva el jugador
                }
            }
            else
            {
                Debug.Log("El jugador ya está muerto y no puede recibir más daño.");
            }
        }
    }



}
