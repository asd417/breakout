using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ball : MonoBehaviour
{
    float maxVelocity = 15.0f;
    Rigidbody2D body;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(body.velocity.magnitude > maxVelocity)
        {
            Debug.Log("SPEED OVER 1");
            body.velocity = Vector3.ClampMagnitude(body.velocity, maxVelocity);
        }
            
    }
}
