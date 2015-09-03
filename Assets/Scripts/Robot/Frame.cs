using UnityEngine;
using System.Collections;

public class Frame : MonoBehaviour
{

    public Vector3 headPoint;
    public Vector3 torsoPoint;
    public Vector3 armPoint;
    public Vector3 locomotionPoint;
    public Vector3 movePoint;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void GlobalFunction()
    {
        Debug.Log("Global Class Function");
    }

    public virtual void VirtualFunction()
    {
        Debug.Log("Global Version Function");
    }
}
