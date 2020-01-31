using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class NarrativeText : MonoBehaviour
{
    private Rigidbody rb;

    
    private void OnCollisionEnter(Collision other)
    {
        
        Vector3 direction = (transform.position - other.transform.position).normalized;

        
        // get our current speed
        float speed = rb.velocity.magnitude; // magnitude is the length of the vector
 
        // set velocity with the same speed, in the new direction
        rb.velocity = direction * speed;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    protected void LateUpdate()
    {
        transform.localEulerAngles = new Vector3(transform.localRotation.x, -90,90);
    }
}
