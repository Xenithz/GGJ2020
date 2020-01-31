using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    Camera mainCam;

    private void Start()
    {
        mainCam = Camera.main;
        Debug.Log("Cam: " + mainCam);
    }
    void Update()
    {
        transform.LookAt(mainCam.transform);
    }
}
