using UnityEngine;

public class EnemyAI1 : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float shootingRange = 10f;
    public float shootingCooldown = 2f;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float health = 100f;

    private Transform player;
    private float lastShotTime;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        lastShotTime = Time.time;
    }

    private void Update()
    {
        if (player == null)
            return;

        // Move towards the player
        transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);

        // Check if in shooting range
        if (Vector3.Distance(transform.position, player.position) <= shootingRange)
        {
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
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();

        if (bulletRigidbody != null)
        {
            // Set bullet's velocity towards the player
            Vector3 direction = (player.position - firePoint.position).normalized;
            bulletRigidbody.velocity = direction * 10f; // Adjust the speed as needed
        }
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
        // Perform death actions (e.g., play death animation, drop items, etc.)
        Destroy(gameObject);
    }
}
