using UnityEngine;

public class jump : MonoBehaviour
{
    public float jumpForce = 5f; // Adjust as needed
    public Rigidbody rb;

    void Update()
    {
        // Jump when space is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
