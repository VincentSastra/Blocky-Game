using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float accel = 0.1f;


    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = new Vector2(0f, 0f);
    }
    
    float maxVelocity = 6f;
    void FixedUpdate()
    {
    rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxVelocity);
    }

    // Update is called once per frame, movement
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow)|| Input.GetKey(KeyCode.W))
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + accel);
        }
        if (Input.GetKey(KeyCode.RightArrow)|| Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(rb.velocity.x - accel, rb.velocity.y);
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(rb.velocity.x + accel, rb.velocity.y);
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y - accel);
        }
        

    
    
    }
}
