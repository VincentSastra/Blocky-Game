using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float accel = 5f;
    public float maxVelocity = 6f;
    public float initialVelocity = 2f;
    public float dash = 12f;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = new Vector2(0f, 0f);
    }
    
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
        
        if (rb.velocity.magnitude < maxVelocity) {
            rb.AddForce(direction.normalized * accel);
        }

        if (rb.velocity.magnitude < 1f) {
            rb.velocity = direction.normalized * initialVelocity;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            rb.velocity += direction.normalized * dash;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
