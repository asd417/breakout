using UnityEngine;

public class SpinningBrick : Brick
{
    public float initialSpin = 100f;

    private Rigidbody2D rb;

    void Start()
    {
        health = 3;
        rb = GetComponent<Rigidbody2D>();

        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody2D>();
        }
        rb.angularVelocity = initialSpin;

        rb.drag = 0;
        rb.angularDrag = 0;
    }
}