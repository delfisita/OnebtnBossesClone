using Unity.VisualScripting;
using UnityEngine;

public class proyectienemigo : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 2f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

       
        rb.AddForce(transform.right * speed, ForceMode2D.Impulse);

        Destroy(gameObject, lifeTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject); 
        }
    }

}

