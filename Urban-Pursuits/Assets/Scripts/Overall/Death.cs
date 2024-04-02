using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene loading

public class Death : MonoBehaviour
{
    public Transform respawnPoint; // Reference to the initial respawn point (assign in the Inspector)
    private int respawnCount = 0; // Counter for respawns

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is the player (you can adjust the tag as needed)
        if (other.CompareTag("Player"))
        {
            // Move the player to the updated respawn point
            other.transform.position = respawnPoint.position;

            // Increment the respawn count
            respawnCount++;

            // Check if the respawn count reaches 3
            if (respawnCount >= 5)
            {
                // Load the "GameOver" scene or perform any other game over logic
                SceneManager.LoadScene("Game Over");
            }
        }
    }
}
