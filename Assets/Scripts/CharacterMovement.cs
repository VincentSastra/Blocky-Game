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
        Vector2 direction = new Vector2(0, 0);
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            direction.y += 1;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            direction.x += 1;
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            direction.x += -1;
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            direction.y += -1;
        }
        
        rb.AddForce(direction * 1f);

        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxVelocity);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
