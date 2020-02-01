using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoCubeFallDetector : MonoBehaviour
{
    public OLetterGlow oLetter;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("NoBoxCollider"))
        {
            GetComponent<Rigidbody>().isKinematic = false;
            oLetter.Activate();
        }
    }
}
