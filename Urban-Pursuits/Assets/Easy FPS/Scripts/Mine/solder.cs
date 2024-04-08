using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform player; // Reference to the player transform
    private NavMeshAgent navAgent;

    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        if (player == null)
        {
            Debug.LogError("Please assign the player transform in the inspector!");
        }
    }

    void Update()
    {
        if (player != null)
        {
            navAgent.SetDestination(player.position);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Handle player death logic here (e.g., call player death function, play animation)
            Debug.Log("Player Died!");
            // (Optional) Destroy enemy on touch (if desired)
            // Destroy(gameObject);
        }
    }
}
