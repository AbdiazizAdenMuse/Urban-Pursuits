using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float damageAmount = 20f; // Amount of damage the bullet inflicts

    private void OnTriggerEnter(Collider other)
    {
        // Check if the bullet collides with the player
        if (other.CompareTag("Player"))
        {
            // Get the PlayerHealth component from the player GameObject
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            // If the playerHealth is not null, apply damage to the player
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
            }

            // Destroy the bullet
            Destroy(gameObject);
        }
    }
}
