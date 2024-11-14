using UnityEngine;

public class NewBehaviouScript : MonoBehaviour
{
    private Vector3 startPosition; // Store the starting position

    void Start()
    {
        // Record the starting position of the player
        startPosition = transform.position;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player collided with an object tagged as "Obstacle"
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // Reset the player's position to the starting position
            transform.position = startPosition;
            Debug.Log("Player reset to start position"); // Debug log for collision
        }
    }
}

