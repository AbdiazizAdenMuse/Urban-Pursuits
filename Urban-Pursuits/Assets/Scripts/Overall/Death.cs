using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    public Transform respawnPoint;
    private int respawnCount = 0;
    [SerializeField] TextMeshProUGUI liveCount;
    int liveCountIndex = 5;
    private bool hasTriggered = false; // Flag to track if the trigger has been activated

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is the player and the trigger hasn't been activated yet
        if (other.CompareTag("Player") && !hasTriggered)
        {
            hasTriggered = true; // Set the flag to true
            liveCountIndex -= 1;
            other.transform.position = respawnPoint.position;
            liveCount.text = liveCountIndex.ToString();

            respawnCount++;

            // Check if liveCountIndex is less than or equal to zero or respawnCount is greater than 7
            if (liveCountIndex <= 0 || respawnCount > 7)
            {
                SceneManager.LoadScene("Game Over");
            }
        }
    }

    // You might also want to reset the trigger flag when the player leaves the collider
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hasTriggered = false;
        }
    }
}
