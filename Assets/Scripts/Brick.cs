using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public int health = 1;
    public int score = 1;

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision != null)
        {
            if(collision.transform.CompareTag("ball"))
            {
                health -= 1;
            }
        }
    }

    void Update()
    {
        if (health <= 0)
        {
            PlayerController player = GameObject.Find("player").GetComponent<PlayerController>();
            player.BroadcastMessage("gainScore", score);
            Destroy(gameObject);
        }
    }
}
