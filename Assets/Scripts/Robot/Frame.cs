using UnityEngine;
using System.Collections;
using Pathfinding;

public class Frame : MonoBehaviour
{

    public Vector3 VisionPoint;
    public Vector3 FacingPoint;
    public Vector3 ItemPoint;
    public Vector3 LocomotionPoint;

    public Vector3 MovePoint;
    private Seeker _seeker;
    public GameObject PropulsionPrefab;
    public GameObject AttachedPropulsion;
    private Propulsion _propulsionScript;
    private const float RepathTimeoutInterval = 5.0f;
    private float _repathTimeout;

	public void Start ()
	{
	    _seeker = GetComponent<Seeker>();
	    _repathTimeout = RepathTimeoutInterval;
	    _propulsionScript = AttachedPropulsion.GetComponent<Propulsion>();
	}
	
	void Update ()
	{
        /*
        //Force a repath every 5 seconds
	    _repathTimeout -= Time.deltaTime;
	    if (_repathTimeout < 0.0f)
	    {
	        UpdatePath();
	        _repathTimeout = RepathTimeoutInterval;
            Debug.Log(gameObject.name + " generated new path.");
	    }
        */
	}

    public void UpdateMoveLocation(Vector3 location)
    {
        MovePoint = location;
        UpdatePath();
    }

    public void UpdatePath()
    {
        _seeker.StartPath(transform.position, MovePoint, OnPathComplete);
    }

    private void OnPathComplete(Path p)
    {
        Debug.Log("Path found. Error: " + p.error);
        _propulsionScript.UpdateMovementLocation(p);
    }
}
