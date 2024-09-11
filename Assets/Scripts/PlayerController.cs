using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerController : MonoBehaviour
{
    float velocity;
    float friction = 0.99f;
    Ball ball;
    void Start()
    {
        ball = GameObject.Find("ball").GetComponent<Ball>();

    }

    void FixedUpdate()
    {
        if (Input.GetKey("right") || Input.GetKey("d"))
        {
            velocity += 0.01f;
        }
        else if (Input.GetKey("left") || Input.GetKey("a"))
        {
            velocity -= 0.01f;
        }
        else
        {
            velocity *= friction;
        }

        if (Input.GetKey("space") || Input.GetKey("up"))
        {
            ball.BroadcastMessage("Launch");
        } else if (Input.GetKey("down") || Input.GetKey("r"))
        {
            ball.BroadcastMessage("Reset");
        }

        if (Mathf.Abs(transform.position.x) > 7.0f)
        {
            if (transform.position.x < 0)
            {
                velocity = Mathf.Abs(velocity);
            }
            else
            {
                velocity = -Mathf.Abs(velocity);
            }
            velocity *= 0.9f;
        }
        transform.position = transform.position + new Vector3(velocity, 0, 0);
    }
}
