using UnityEngine;

public class FallCounter : MonoBehaviour
{
    public ShootText brokenTextShoot;

    public int currentBreakCount, maxBreakCount;

    public Rigidbody playerRigidbody;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) ||
            Input.GetKeyDown(KeyCode.D))
        {
            currentBreakCount++;
        }

        if (currentBreakCount >= maxBreakCount)
        {
            brokenTextShoot.Shoot();
            playerRigidbody.isKinematic = false;
            enabled = false;
        }
    }
}