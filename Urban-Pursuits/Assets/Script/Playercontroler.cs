using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 5f;

    [SerializeField]
    float rotationSpeed = 500f;

    Quaternion targetRotation;
    CameraController cameraController;
    Animator animator;

    private void Awake()
    {
        cameraController = Camera.main.GetComponent<CameraController>();
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator component is not assigned.");
        }
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        float moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
        Vector3 moveInput = (new Vector3(horizontalInput, 0, verticalInput)).normalized;
        Vector3 moveDirection = cameraController.PlanarRotation * moveInput;

        if (moveAmount > 0)
        {
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
            targetRotation = Quaternion.LookRotation(moveDirection);
        }

        transform.rotation = Quaternion.RotateTowards(
            transform.rotation,
            targetRotation,
            rotationSpeed * Time.deltaTime
        );

        if (animator != null)
        {
            animator.SetFloat("moveAmount", moveAmount);
        }
        else
        {
            Debug.LogError("Animator component is not assigned.");
        }
    }
}
