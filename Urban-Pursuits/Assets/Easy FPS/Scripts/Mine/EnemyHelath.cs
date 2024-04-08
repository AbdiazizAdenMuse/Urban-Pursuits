using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 100f; // Maximum health of the enemy
    private float currentHealth; // Current health of the enemy

    private void Start()
    {
        currentHealth = maxHealth; // Initialize current health to maximum health
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount; // Reduce enemy's health by damage amount

        if (currentHealth <= 0)
        {
            Die(); // If health drops to or below 0, call Die() method
        }
    }

    void Die()
    {
        // Perform any death actions here (e.g., play death animation, game over screen, etc.)
        Debug.Log("Enemy died!"); // Example: Log a message to the console
        Destroy(gameObject); // Destroy the enemy GameObject
    }
}
