using UnityEngine;
using System.Collections;

public class Module : MonoBehaviour
{

    private Frame _parentReference;

	// Use this for initialization
	void Start ()
	{
	    _parentReference = transform.parent.GetComponent<Frame>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
