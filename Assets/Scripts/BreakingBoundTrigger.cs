using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingBoundTrigger : MonoBehaviour
{
    [SerializeField] private float bounceTourque;

  
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Broken"))
        {

            StartCoroutine((LerpTextBox(other.transform)));
            Debug.Log("jshdjs");
        }
    }

    IEnumerator LerpTextBox(Transform target)
    {

        Quaternion startRotation = transform.rotation;
        float startTime = Time.time;
        float perc;
        float remainingTime;
        
        while (target.rotation != Quaternion.identity)
        {

            remainingTime = Time.time - startTime;
            perc = remainingTime / 2f;
            target.rotation = Quaternion.Lerp(startRotation,Quaternion.identity, perc);
            yield return null;
        }
        
        
        
    }
}
