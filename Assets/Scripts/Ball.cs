using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Ball : MonoBehaviour
{
    float maxVelocity = 15.0f;
    Rigidbody2D rb;
    bool held;
    void Start()
    {
        held = true;
        rb = transform.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (held)
        {
            IsHeld();
        }
        else
        {
            InPlay();
        }
            
    }
    void Launch()
    {
        if (held)
        {
            held = false;
            float randx = Random.Range(-5, 5);
            rb.velocity = new Vector2(randx, 10);
        }
    }

    private void Reset()
    {
        held = true;
        rb.velocity = new Vector2(0,0);
        IsHeld();
    }

    void InPlay()
    {
        if (rb.velocity.magnitude > maxVelocity)
        {
            Debug.Log("SPEED OVER 1");
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxVelocity);
        }
    }

    void IsHeld()
    {
        Vector2 playerPos = GameObject.Find("player").GetComponent<Transform>().position;
        transform.position = playerPos + new Vector2(0, 0.5f);
    }
}
