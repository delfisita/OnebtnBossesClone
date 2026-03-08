using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootingSpecial : MonoBehaviour
{
    [Header("Pool & FirePoint")]
    public ObjectPool projectilePool;
    public Transform firePoint;

    [Header("Timing")]
    public float timeBetweenBursts = 5f;
    public float timeForStartShooting = 4f;
    public float burstDuration = 3f;
    public float fireRate = 0.12f;

    [Header("Projectile")]
    public float projectileSpeed = 6f;
    public float returnDelay = 3f;

    [Header("Cross Settings")]
    public CrossPattern pattern = CrossPattern.Cross4;
    public float rotationSpeed = 60f;


    public enum CrossPattern
    {
        Cross4,
        Cross8,
        Cross4Rotating
    }

    private float rotationOffset = 0f;

    void Start()
    {
        StartCoroutine(BurstLoop());
    }

    IEnumerator BurstLoop()
    {
        
        yield return new WaitForSeconds(timeForStartShooting);

        while (true)
        {
            yield return StartCoroutine(DoBurst());
            yield return new WaitForSeconds(timeBetweenBursts);
        }
    }

    IEnumerator DoBurst()
    {
        float elapsed = 0f;
        rotationOffset = 0f; 

        while (elapsed < burstDuration)
        {
            
            ShootCross();
            rotationOffset += rotationSpeed * fireRate; 
            yield return new WaitForSeconds(fireRate);
            elapsed += fireRate;
            
        }
    }

    void ShootCross()
    {
        float[] angles;

        switch (pattern)
        {
            case CrossPattern.Cross8:
                angles = new float[] { 0, 45, 90, 135, 180, 225, 270, 315 };
                break;

            default: 
                angles = new float[] { 0, 90, 180, 270 };
                break;
        }

        foreach (float angle in angles)
            FireInDirection(angle + rotationOffset);
    }

    void FireInDirection(float angleDegrees)
    {
        GameObject projectile = projectilePool.GetObject();
        projectile.transform.position = firePoint.position;
        projectile.transform.rotation = firePoint.rotation;

        Projectile projectileComponent = projectile.GetComponent<Projectile>();
        if (projectileComponent != null)
            projectileComponent.objectPool = projectilePool;

        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            float rad = angleDegrees * Mathf.Deg2Rad;
            Vector2 dir = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad)).normalized;
            rb.velocity = dir * projectileSpeed;
        }

        StartCoroutine(ReturnProjectileToPool(projectile, returnDelay));
    }

    private IEnumerator ReturnProjectileToPool(GameObject projectile, float delay)
    {
        yield return new WaitForSeconds(delay);
        if (projectile != null && projectile.activeInHierarchy)
            projectilePool.ReturnObject(projectile);
    }
}
