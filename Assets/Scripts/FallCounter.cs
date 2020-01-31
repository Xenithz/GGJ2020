using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallCounter : MonoBehaviour
{

    public BrokenText brokenText;
    public Rigidbody playerRigidbody;
    public ShootText brokenTextShoot;
    
    public int currentBreakCount, maxBreakCount;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) ||
            Input.GetKeyDown(KeyCode.D))
        {
            currentBreakCount++;
        }

        if (currentBreakCount >= maxBreakCount)
        {
            brokenTextShoot.Shoot();
            //brokenText.Break();
            playerRigidbody.isKinematic = false;
       
            this.enabled = false;
        }
    }
}
