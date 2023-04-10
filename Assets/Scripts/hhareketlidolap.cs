using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hhareketlidolap : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 5;
    public float forceSpeed;

    public bool timer;

    void Start()
    {
        forceSpeed = speed;
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        rb.velocity = transform.forward * forceSpeed;
        rb.velocity = Vector3.forward * forceSpeed;

        rb.velocity = Vector3.left * forceSpeed;
        

        if(timer)
        {
            if ( forceSpeed> 0 )
            {
                forceSpeed = -speed;
                timer = false;
            }
            else if ( forceSpeed < 0 ) 
            {
                forceSpeed = speed;
                timer = false;  
            }

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Untagged")
        {
            timer = true;
        }
    }
}
