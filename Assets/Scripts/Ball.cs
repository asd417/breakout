using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.WSA;

public class Ball : MonoBehaviour
{
    float maxVelocity = 8.0f;
    public Rigidbody2D rb;
    public bool held;
    public Text loseText;
    public Text winText;
    public TrailRenderer trail;
    public AudioSource speaker;
    public bool winState = false;


    void Start()
    {
        held = true;
        loseText.enabled = false;
        winText.enabled = false;
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

    public void showLoseText()
    {
        if (!winState)
        {
            loseText.enabled = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        speaker.pitch = 1.1f - 0.2f * Random.value;
        speaker.volume = 0.5f;
        speaker.Play();
    }

    void Launch()
    {
        if (held)
        {
            PlayerController player = GameObject.Find("player").GetComponent<PlayerController>();
            player.BroadcastMessage("setScore");
            trail.emitting   = true;
            held = false;
            float randx = Random.Range(-5, 5);
            rb.velocity = new Vector2(randx, 10);
            winState = false;
            loseText.enabled = false;
            winText.enabled = false;
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
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxVelocity);
        }
        if (rb.velocity.magnitude < maxVelocity)
        {
            rb.velocity = Vector2.ClampMagnitude(rb.velocity*1.1f, maxVelocity);
        }
    }

    void IsHeld()
    {
        Vector2 playerPos = GameObject.Find("player").GetComponent<Transform>().position;
        transform.position = playerPos + new Vector2(0, 0.5f);
    }
}
