using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public int health = 1;

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision != null)
        {
            if(collision.transform.CompareTag("ball"))
            {
                Debug.Log("Ball Collided");
                health -= 1;
            }
        }
    }

    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
