using System.Collections;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    public Transform[] shootingPoints; // Puntos de disparo
    public GameObject projectilePrefab; // Prefab del proyectil
    public GameObject obstaclePrefab; // Prefab del obstáculo
    public GameObject conePrefab; // Prefab del cono

    public float shootingInterval = 1.5f; // Intervalo entre disparos
    public float attackInterval = 5f; // Intervalo entre ataques especiales
    public float circleRadius = 5f; // Radio del círculo para ataques

    private EnemyHealth enemyHealth;

    private void Start()
    {
        enemyHealth = GetComponent<EnemyHealth>(); 

        foreach (Transform shootingPoint in shootingPoints)
        {
            StartCoroutine(ActivateShootingPoint(shootingPoint));
        }

        StartCoroutine(SpecialAttacks());
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

    private IEnumerator SpecialAttacks()
    {
        while (enemyHealth.health > 0)
        {
            yield return new WaitForSeconds(attackInterval);

            int randomAttack = Random.Range(1, 4); 
            switch (randomAttack)
            {
                case 1:
                    RandomObstacleAttack();
                    break;
                case 2:
                    ConeAngleAttack();
                    break;
                case 3:
                    StraightProjectileAttack();
                    break;
            }
        }
    }

    private void RandomObstacleAttack()
    {
        Vector2 randomPosition = GetRandomPointOnCircleEdge(circleRadius);
        Instantiate(obstaclePrefab, randomPosition, Quaternion.identity);
    }

    private void ConeAngleAttack()
    {
        float randomAngle = Random.Range(0, 360);
        Vector2 conePosition = GetPointOnCircleEdge(randomAngle, circleRadius);
        Quaternion coneRotation = Quaternion.Euler(0, 0, randomAngle);
        Instantiate(conePrefab, conePosition, coneRotation);
    }

    
    private void StraightProjectileAttack()
    {
        Vector2 spawnPosition = (Vector2)transform.position + Random.insideUnitCircle * 1.5f;
        GameObject projectile = Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            Vector2 direction = (spawnPosition - (Vector2)transform.position).normalized;
            rb.velocity = direction * 5f;
        }
    }

    // Métodos auxiliares
    private Vector2 GetRandomPointOnCircleEdge(float radius)
    {
        float angle = Random.Range(0, 2 * Mathf.PI);
        return new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * radius;
    }

    private Vector2 GetPointOnCircleEdge(float angle, float radius)
    {
        float radians = angle * Mathf.Deg2Rad;
        return new Vector2(Mathf.Cos(radians), Mathf.Sin(radians)) * radius;
    }
}
