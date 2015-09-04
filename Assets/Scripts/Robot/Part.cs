using UnityEngine;
using System.Collections;

public class Part : MonoBehaviour
{
    //Part Stats
    public float HeatShutdown;
    public float HeatDestroy;
    public float EnergyDraw;
    public float TotalDurablity;
    public float HeatTransferRadius;
    public string PartType;

    //Tracking of part status
    public float Durability;
    public float Heat;

    //References to other components
    //ref to frame script
    //ref to heat transfer collider

	void Start () {
	
	}
	
	void Update () {
	
	}
}
