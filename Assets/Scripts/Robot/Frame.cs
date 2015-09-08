using UnityEngine;
using System.Collections;
using Pathfinding;

public class Frame : MonoBehaviour
{

    public Vector3 visionPoint;
    public Vector3 facingPoint;
    public Vector3 itemPoint;
    public Vector3 locomotionPoint;

    public Vector3 movePoint;
    private Seeker _seeker;
    private const float RepathTimeoutInterval = 5.0f;
    private float _repathTimeout;

	public void Start ()
	{
	    _seeker = GetComponent<Seeker>();
	    _repathTimeout = RepathTimeoutInterval;
	}
	
	void Update ()
	{
        //Force a repath every 5 seconds
	    _repathTimeout -= Time.deltaTime;
	    if (_repathTimeout < 0.0f)
	    {
	        UpdatePath();
	        _repathTimeout = RepathTimeoutInterval;
            Debug.Log(gameObject.name + " generated new path.");
	    }
	}

    public void UpdateMoveLocation(Vector3 location)
    {
        movePoint = location;
        UpdatePath();
    }

    private void UpdatePath()
    {
        _seeker.StartPath(transform.position, movePoint, OnPathComplete);
    }

    private void OnPathComplete(Path p)
    {
        Debug.Log("Path found. Error: " + p.error);
    }
}
