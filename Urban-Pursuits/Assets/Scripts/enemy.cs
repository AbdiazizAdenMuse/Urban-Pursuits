using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float shootingRange = 10f;
    public float minDistance = 5f; // Minimum distance the enemy should maintain from the player
    public float maxDistance = 15f; // Maximum distance the enemy should maintain from the player
    public float shootingCooldown = 2f;
    public GameObject bulletPrefab;
    public float health = 100f;
    public float bulletDamage = 20f; // Amount of damage inflicted by each bullet

    private Transform player;
    private float lastShotTime;
    private Animator animator;
    private int shotsTaken = 0;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        lastShotTime = Time.time;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (player == null)
            return;

        // Calculate the distance between the enemy and the player
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Check if the enemy is within the desired distance range
        if (distanceToPlayer >= minDistance && distanceToPlayer <= maxDistance)
        {
            // If the enemy is within the range, stop moving and play idle animation
            animator.SetBool("run", false);
        }
        else
        {
            // If the enemy is not within the range, play running animation
            animator.SetBool("run", true);
        }

        // Move towards the player while maintaining minimum distance
        if (distanceToPlayer > maxDistance)
        {
            // If the player is too far, move towards the player
            transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }
        else if (distanceToPlayer < minDistance)
        {
            // If the player is too close, move away from the player
            transform.position = Vector3.MoveTowards(transform.position, player.position, -moveSpeed * Time.deltaTime);
        }

        // Check if in shooting range
        if (Vector3.Distance(transform.position, player.position) <= shootingRange)
        {
            // Rotate towards the player
            transform.LookAt(player);

            // Shoot if cooldown time has passed
            if (Time.time - lastShotTime >= shootingCooldown)
            {
                Shoot();
                lastShotTime = Time.time;
            }
        }
    }

    void Shoot()
    {
        // Instantiate bullet
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();

        if (bulletRigidbody != null)
        {
            // Set bullet's velocity towards the player
            Vector3 direction = (player.position - transform.position).normalized;
            bulletRigidbody.velocity = direction * 10f; // Adjust the speed as needed
        }

        // Trigger shooting animation
        animator.SetTrigger("shoot");
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Trigger death animation
        animator.SetTrigger("die");
        // Perform death actions (e.g., play death animation, drop items, etc.)
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the bullet collides with the player
        if (other.CompareTag("PlayerBullet"))
        {
            shotsTaken++;
            Destroy(other.gameObject); // Destroy the player bullet
            if (shotsTaken >= 5) // Adjust the number of shots as needed
            {
                Die(); // If enough shots are taken, destroy the enemy
            }
        }
    }
}
