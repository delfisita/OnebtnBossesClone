using UnityEngine;

public class DisparoProyectil : MonoBehaviour
{
    [SerializeField] private float attackSpeed;
    [SerializeField] private string proyectilPoolName; // nombre del prefab de la bala deseada en este caso la del player
    [SerializeField] private Transform target;
    private float nextTimeToShoot;

    private void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if (nextTimeToShoot > Time.time) return;

        nextTimeToShoot = Time.time + 1 / attackSpeed;

        // Obtener proyectil del pool
        GameObject proyectil = PoolingObjects.Instance.GetPooledObject(proyectilPoolName);

        if (proyectil != null)
        {
            proyectil.transform.position = transform.position;
            proyectil.transform.rotation = Quaternion.identity;
            proyectil.GetComponent<proyectil>().Target = target;
        }
        
    }
}

