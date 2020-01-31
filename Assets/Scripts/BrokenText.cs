using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenText : MonoBehaviour
{
    private HingeJoint hinge;
    private void Start()
    {
        hinge = GetComponent<HingeJoint>();
        Invoke("Break", 3f);
    }
    void Break()
    {
        hinge.breakForce = 50f;
        
    }
}
