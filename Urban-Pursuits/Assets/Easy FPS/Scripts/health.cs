using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f; // Maximum health of the player
    private float currentHealth; // Current health of the player

    private void Start()
    {
        currentHealth = maxHealth; // Initialize current health to maximum health
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount; // Reduce player's health by damage amount

        if (currentHealth <= 0)
        {
            Die(); // If health drops to or below 0, call Die() method
        }
    }

    void Die()
    {
        // Perform any death actions here (e.g., play death animation, game over screen, etc.)
        Debug.Log("Player died!"); // Example: Log a message to the console
        Destroy(gameObject); // Destroy the player GameObject
    }
}
