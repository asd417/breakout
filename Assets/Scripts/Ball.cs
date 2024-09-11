using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Ball : MonoBehaviour
{
    float maxVelocity = 15.0f;
    Vector2 velocity;
    bool held;
    void Start()
    {
        held = true;
        velocity = Vector2.zero;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        ReflectDirection(other.gameObject);
        Debug.Log("Collided with " + other.gameObject.name);
    }

    void ReflectDirection(GameObject wall)
    {
        if (wall.CompareTag("wall") || wall.CompareTag("Player"))
        {
            velocity = new Vector2(velocity.x, -velocity.y);
        }
        else if (wall.CompareTag("sideWall"))
        {
            velocity = new Vector2(-velocity.x, velocity.y);
        }
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
            velocity = new Vector2(randx, 10);
        }
    }

    private void Reset()
    {
        held = true;
        velocity = Vector2.zero;
        IsHeld();
    }

    void InPlay()
    {
        transform.Translate(velocity * Time.deltaTime);
        if (velocity.magnitude > maxVelocity)
        {
            Debug.Log("SPEED OVER 1");
            velocity = Vector2.ClampMagnitude(velocity, maxVelocity);
        }
    }

    void IsHeld()
    {
        Vector2 playerPos = GameObject.Find("player").GetComponent<Transform>().position;
        transform.position = playerPos + new Vector2(0, 0.5f);
    }
}
