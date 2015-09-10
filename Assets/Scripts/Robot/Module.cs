using UnityEngine;
using System.Collections;

public class Module : MonoBehaviour
{
    private Frame _parentReference;

    // Use this for initialization
    private void Start()
    {
        _parentReference = transform.parent.GetComponent<Frame>();
    }

    // Update is called once per frame
    private void Update()
    {
    }
}