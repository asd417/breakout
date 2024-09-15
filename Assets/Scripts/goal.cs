using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ball"))
        {
            Ball ball = GameObject.Find("ball").GetComponent<Ball>();
            BrickGenerator bg = GameObject.Find("BrickGenerator").GetComponent<BrickGenerator>();
            ball.showLoseText();
            ball.rb.velocity = new Vector2(0, 0);
            ball.held = true;
            bg.ResetBricks();
            bg.GenerateBricks(8, 3);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
