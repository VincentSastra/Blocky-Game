using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public float accel = 5f;
    public float maxVelocity = 6f;
    public float initialVelocity = 2f;
    public float dash = 12f;

    private float lastDash;

    // Start is called before the first frame update
    void Start()
    {
        lastDash = -10;
        rb.velocity = new Vector2(0f, 0f);
    }
}