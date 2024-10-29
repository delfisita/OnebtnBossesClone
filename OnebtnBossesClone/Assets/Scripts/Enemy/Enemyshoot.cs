using System.Collections;
using UnityEngine;

public class Enemyshoot : MonoBehaviour
{
    public Transform[] shootingPoints; // Array de puntos de disparo (hijos)
    public GameObject projectilePrefab; // Prefab del proyectil a disparar
    public float shootingInterval = 1.5f; // Intervalo general de disparo entre los puntos
    
    private void Start()
    {
        
        foreach (Transform shootingPoint in shootingPoints)
        {
            StartCoroutine(ActivateShootingPoint(shootingPoint));
        }
    }

    private IEnumerator ActivateShootingPoint(Transform shootingPoint)
    {
        while (true)
        {
            
            Shoot(shootingPoint);
            yield return new WaitForSeconds(shootingInterval); 
        }
    }

    private void Shoot(Transform shootingPoint)
    {
        
        Instantiate(projectilePrefab, shootingPoint.position, shootingPoint.rotation);
    }
}
