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

    private float lastDash;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        lastDash = -10;
        rb.velocity = new Vector2(0f, 0f);
        anim = GetComponent<Animator>();
    }
    
    void FixedUpdate()
    {
        Vector2 direction = getDirection();
        
        if (rb.velocity.magnitude < maxVelocity) {
            rb.AddForce(direction.normalized * accel);
        }

        if (rb.velocity.magnitude < 1f) {
            rb.velocity = direction.normalized * initialVelocity;
        }

        if (direction != Vector2.zero) {
            anim.SetBool("isRunning", true);
        } else {
            anim.SetBool("isRunning", false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && Time.time - lastDash > 0.5) {
            lastDash = Time.time;
            rb.velocity += getDirection().normalized * dash;
        }
    }

    private Vector2 getDirection() {
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

        return direction;
    }
}