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
        Ball ball = GameObject.Find("ball").GetComponent<Ball>();
        ball.loseText.enabled = true;
        ball.rb.velocity = new Vector2(0, 0);
        ball.held = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
