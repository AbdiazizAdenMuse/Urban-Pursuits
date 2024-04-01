using UnityEngine;

public class automove : MonoBehaviour
{
    [SerializeField] private WaypointPath _waypointPath;
    [SerializeField] private float _speed;

    private int _targetWaypointIndex;
    private Transform _targetWaypoint;
    private bool isMoving = false;

    void Start()
    {
        TargetNextWaypoint();
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            float step = _speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, _targetWaypoint.position, step);

            if (transform.position == _targetWaypoint.position)
            {
                TargetNextWaypoint();
            }
        }
    }

    private void TargetNextWaypoint()
    {
        _targetWaypointIndex = _waypointPath.GetNextWaypointIndex(_targetWaypointIndex);
        _targetWaypoint = _waypointPath.GetWaypoint(_targetWaypointIndex);

        if (_targetWaypointIndex == 0)
        {
            isMoving = false; // Stop moving when reaching the last waypoint
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.isTrigger)
        {
            other.transform.SetParent(transform);
        }
        isMoving = true; // Start moving when something triggers the platform
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.isTrigger)
        {
            other.transform.SetParent(null);
        }
    }
}
