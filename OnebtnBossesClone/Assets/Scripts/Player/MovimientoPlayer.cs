using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPlayer : MonoBehaviour
{
  
        public float radius = 5.0f;       
        public float speed = 2.0f;       
        private float angle = 0.0f;       

        void Update()
        {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            speed = -speed; 
        }
        angle += speed * Time.deltaTime;

           
            float x = Mathf.Cos(angle) * radius;
            float y = Mathf.Sin(angle) * radius;

            
            transform.position = new Vector3(x, y, transform.position.z);
    }
       
    }


