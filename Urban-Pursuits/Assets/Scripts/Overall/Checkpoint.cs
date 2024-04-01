using UnityEngine;

public class Checkpoint : MonoBehaviour
{public Transform respawnPoint; // Reference to the initial respawn point (assign in the Inspector)

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is the player (you can adjust the tag as needed)
        if (other.CompareTag("Player"))
        {
            // Update the respawn point to the current platform's position
            respawnPoint.position = transform.position;
        }
    }
}
