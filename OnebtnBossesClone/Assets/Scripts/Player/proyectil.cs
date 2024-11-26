using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class proyectil : MonoBehaviour
{
    [SerializeField] private float shootSpeed;
    [SerializeField] private float _projectileDamage;
   
    private Transform target;
    public Transform Target { get => target; set => target = value; }

    private void Start()
    {
        SetRotation();
     
    }

    private void Update()
    {
        
        
        ProjectileBehaviour();
    }

    private void SetRotation()
    {
        Vector3 directionToTarget;

        if (target != null)
            directionToTarget = (target.position - transform.position).normalized;
        else
            directionToTarget = (Vector3.zero - transform.position).normalized;

        float angle = (Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg) - 90;
        transform.eulerAngles = new(0f, 0f, angle);
    }

    private void ProjectileBehaviour()
    {
        transform.Translate(Time.deltaTime * shootSpeed * transform.up, Space.World);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(("Enemy")))

        {
            this.gameObject.SetActive(false);   
        }
    }

}

