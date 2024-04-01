using UnityEngine;

public class CubeClick : MonoBehaviour
{
    private Renderer cubeRenderer; // Add this line

    public MovingPlatform movingPlatform;
    private void Start()
    {
        // Get the Renderer component attached to this game object
        cubeRenderer = GetComponent<Renderer>();
    }
    private void OnMouseDown()
    {
        cubeRenderer.material.color = Color.green;

        movingPlatform.isMoving = true;
        // Move the cube to 34.1 in the z direction
        Vector3 newPosition = transform.position;
        newPosition.z = 34.1f;
        transform.position = newPosition;
    }
}
