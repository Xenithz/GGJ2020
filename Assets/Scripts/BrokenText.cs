using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenText : MonoBehaviour
{
    private HingeJoint hinge;
    private void Start()
    {
        hinge = GetComponent<HingeJoint>();
    }

    private void Update()
    {
       // transform.eulerAngles = new Vector3(0f,0f,transform.eulerAngles.z);
    }

    public void Break()
    {
        hinge.breakForce = 50f;
    }
}
