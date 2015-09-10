using UnityEngine;
using System.Collections;
using Pathfinding;

public class Propulsion : Module
{
    public float NextWaypointDistance;

    private Path _waypoints;
    private int _currentWaypoint = 0;
    private int tempSpeed = 6;

    private void Update()
    {
        //only activate if can draw enough power
        ActivatePropulsion();
    }

    private void ActivatePropulsion()
    {
        //If path exists and there are still nodes to traverse
        if (_waypoints == null) return;
        if (_currentWaypoint >= _waypoints.vectorPath.Count) return;

        //Turn Calculations

        //Forward Caluclations
        Vector3 direction = (_waypoints.vectorPath[_currentWaypoint] - transform.position).normalized;
        direction *= tempSpeed * Time.deltaTime;
        Move(direction);

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

    private void Move(Vector3 direction)
    {
        transform.parent.position += direction;
    }
}