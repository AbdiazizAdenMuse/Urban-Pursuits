using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform followTarget;
    [SerializeField] float distance = 5;
    [SerializeField] float miniVerticalAngle = -45;
    [SerializeField] float maxiVerticalAngle = 45;
    [SerializeField] Vector2 framingoffset;
    [SerializeField] float rotationspeed = 2f;

        [SerializeField] bool invertX;

        [SerializeField] bool invertY;


    float rotationY;
    float rotationX;

float invertXVal;
float invertYVal;
    public void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Update()
    {

        (invertXVal, invertYVal) = (invertX ? -1 : 1, invertY ? -1 : 1);
        rotationY += Input.GetAxis("Mouse X") *invertXVal * rotationspeed;
        rotationX += Input.GetAxis("Mouse Y") * invertYVal * rotationspeed;
        rotationX = Mathf.Clamp(rotationX, miniVerticalAngle, maxiVerticalAngle);

        var targetRotation = Quaternion.Euler(rotationX, rotationY, 0);

        var focusPosition = followTarget.position + new Vector3(framingoffset.x, framingoffset.y, 0);

        // Calculate the offset direction (normalized) and then scale it by the distance
        Vector3 offsetDirection = targetRotation * Vector3.forward;
        Vector3 offset = offsetDirection * distance;

        // Apply the rotation to the camera
        transform.rotation = targetRotation;

        // Apply the offset to the follow target's position
        transform.position = focusPosition - offset;
    }
    public Quaternion PlanarRotation => Quaternion.Euler(0, rotationY, 0);
  
    
}
