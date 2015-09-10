using UnityEngine;
using System.Collections;
using Pathfinding;

public class Propulsion : Module
{
    public float NextWaypointDistance;

    private Path _waypoints;
    private int _currentWaypoint;
    private int tempSpeed = 6; //TODO speed is calculated from attached servos
    private float tempTurnRate = 3.0f; //TODO speed is calculated from attached servos
    /// <summary>
    /// When the angle between the Robot's forward direction and the current waypoint is greater than this value then the Robot will only turn towards the current waypoint.
    /// </summary>
    private float TurnOnlyAngle = 20.0f;

    private void Update()
    {
        //TODO only activate if can draw enough power
        Move();
    }

    private void Move()
    {
        //If path exists and there are still nodes to traverse
        if (_waypoints == null) return;
        if (_currentWaypoint >= _waypoints.vectorPath.Count) return;

        //Turn Calculations
        Vector3 direction = (_waypoints.vectorPath[_currentWaypoint] - transform.position).normalized;
        float angle = Vector3.Angle(transform.parent.forward, direction);
        Vector3 rotation = Vector3.RotateTowards(transform.parent.forward, direction, tempTurnRate * Time.deltaTime, 0.0f);

        //Forward Caluclations
        Vector3 forwardMovement = transform.parent.forward * tempSpeed * Time.deltaTime;

        //Move parent robot
        transform.parent.rotation = Quaternion.LookRotation(rotation);
        if (angle < TurnOnlyAngle)
        {
            transform.parent.position += forwardMovement;
        }

        //Advance to next node when close enough
        if (Vector3.Distance(transform.position, _waypoints.vectorPath[_currentWaypoint]) < NextWaypointDistance)
        {
            _currentWaypoint++;
        }
    }

    public void UpdateMovementLocation(Path p)
    {
        _waypoints = p;
        _currentWaypoint = 0;
    }
}