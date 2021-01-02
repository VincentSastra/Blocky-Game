using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AIMovement : MonoBehaviour
{
    // Go to the objective
    // If hit a wall, move on the normal
    public MovementObjectives[] movementObjectives;
    public float speed;
    public Rigidbody2D rb;
    private Vector2[] directionVectors;
    // Only keep track of the latest collision
    // Can be stuck on corners
    private Collision2D collision;

    // Start is called before the first frame update
    void Start()
    {
        directionVectors = new Vector2[movementObjectives.Length];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPosition = gameObject.transform.position;
        float nearingTargetModifier = 0;
        for (int i = 0; i < movementObjectives.Length; i++) {
            Vector3 targetPosition = movementObjectives[i].gameObject.transform.position;

            // If object in target position, stop moving
            nearingTargetModifier = Math.Max(nearingTargetModifier, Math.Abs(Mathf.Clamp(Vector3.Distance(targetPosition, currentPosition) - movementObjectives[i].targetDistance, -1, 1)));

            // Get the direction it should be moving
            // Try to get to the objectives with more weight
            directionVectors[i] = movementObjectives[i].weight *
                // If already in range of the objective, stop trying to go to that objective
                Mathf.Clamp(Vector3.Distance(targetPosition, currentPosition) - movementObjectives[i].targetDistance, -1, 1) *
                // The actual normalized direction
                (new Vector2(targetPosition.x - currentPosition.x, targetPosition.y - currentPosition.y)).normalized;
        }

        // TODO: Factor in all the weights
        Vector3 direction = (new Vector3(directionVectors[0].x, directionVectors[0].y, 0)).normalized;
        
        // TODO: If nearing target, start circling around
        if (collision != null) {
            // Some linear algebra here
            // Basically make a plane normal to the surface and only move along the surface
            rb.velocity = Vector3.ProjectOnPlane(direction, currentPosition - collision.transform.position).normalized * nearingTargetModifier * speed;
        } else {
            rb.velocity = direction * nearingTargetModifier * speed;
        }
    }

    void OnCollisionEnter2D(Collision2D col) {
        collision = col;
    }

    void OnCollisionExit2D(Collision2D col) {
        if (collision == col) {
            collision = null;
        }
    }

    [System.Serializable]
    public class MovementObjectives {
        public GameObject gameObject;
        public float weight;
        public float targetDistance;
    }
}
