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

	public void Start ()
	{
	    _seeker = GetComponent<Seeker>();
        _seeker.pathCallback += OnPathComplete;
	}
	
	void Update () {
	
	}

    public void OnDisable()
    {
        _seeker.pathCallback -= OnPathComplete;
    }

    public void RePath()
    {
        _seeker.StartPath(transform.position, movePoint);
    }

    public void OnPathComplete(Path p)
    {
        Debug.Log("Path found. Error: " + p.error);
    }
}
