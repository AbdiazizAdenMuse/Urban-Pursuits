using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class d : MonoBehaviour
{
    public float moveSpeed = 2f; // Speed of platform movement
    public float moveDistance = 5f; // Distance the platform moves up and down

    private Vector3 startPos; // Starting position of the platform
    private Vector3 endPos; // Ending position of the platform
    private bool movingUp = true; // Flag indicating if the platform is moving up

    private void Start()
    {
        startPos = transform.position;
        endPos = startPos + Vector3.up * moveDistance;
    }

    private void Update()
    {
        // Move the platform
        if (movingUp)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPos, moveSpeed * Time.deltaTime);

            if (transform.position == endPos)
                movingUp = false;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, moveSpeed * Time.deltaTime);

            if (transform.position == startPos)
                movingUp = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Make anything that enters the trigger zone a child of the platform
        other.transform.parent = transform;
    }

    private void OnTriggerExit(Collider other)
    {
        // Remove the child-parent relationship when exiting the trigger zone
        other.transform.parent = null;
    }
}
