using UnityEngine;
using System.Collections;
using Pathfinding;

public class Propulsion : Module
{
    public float NextWaypointDistance;

    private Path _waypoints;
    private int _currentWaypoint = 0;
    private int tempSpeed = 6;

	void Update ()
	{
        //If path exists and there are still nodes to traverse
	    if (_waypoints == null) return;
	    if (_currentWaypoint >= _waypoints.vectorPath.Count) return;

        //Movement caluclations
	    Vector3 direction = (_waypoints.vectorPath[_currentWaypoint] - transform.position).normalized;
	    direction *= tempSpeed*Time.deltaTime;
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
