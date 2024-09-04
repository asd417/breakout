using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerController : MonoBehaviour
{
    float velocity;
    float friction = 0.99f;

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
        if(Mathf.Abs(transform.position.x) > 7.0f)
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
