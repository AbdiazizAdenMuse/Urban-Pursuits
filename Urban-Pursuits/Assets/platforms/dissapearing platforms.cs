using System.Collections;
using UnityEngine;

public class DisappearingPlatform : MonoBehaviour
{
    // This function is called when another collider enters the trigger collider
    void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the player
        if (other.gameObject.CompareTag("Player"))
        {
            // Start the coroutine to disable the platform
            StartCoroutine(DisablePlatform());
        }
    }

    IEnumerator DisablePlatform()
    {
        // Wait for 2 seconds
        yield return new WaitForSeconds(2);

        // Disable the platform
        gameObject.SetActive(false);
    }
}
