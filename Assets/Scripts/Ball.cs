using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    float maxVelocity = 15.0f;
    public Rigidbody2D rb;
    public bool held;
    public Text loseText;
    public TrailRenderer trail;


    void Start()
    {
        held = true;
        loseText.enabled = false;
        rb = transform.GetComponent<Rigidbody2D>();
        trail.emitting = false;
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
            trail.emitting   = true;
            held = false;
            float randx = Random.Range(-5, 5);
            rb.velocity = new Vector2(randx, 10);
            loseText.enabled = false;
        }
    }

    private void Reset()
    {
        held = true;
        trail.emitting = false;
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
