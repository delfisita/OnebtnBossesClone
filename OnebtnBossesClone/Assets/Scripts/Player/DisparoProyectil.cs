using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoProyectil : MonoBehaviour
{
    [SerializeField] private float attackSpeed;
   
    [SerializeField] private GameObject proyectilPrefab;
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

        GameObject proyectil = Instantiate(proyectilPrefab, transform.position, Quaternion.identity);
        proyectil.GetComponent<proyectil>().Target = target;
    }
}


