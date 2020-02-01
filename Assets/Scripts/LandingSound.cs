using UnityEngine;

public class LandingSound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip landingClip;
    public float playThreshHold = 1;

    public float timeSinceLastPlayed;


    private void OnTriggerEnter(Collider other)
    {
        if (timeSinceLastPlayed > playThreshHold)
        {
            audioSource.PlayOneShot(landingClip);
            timeSinceLastPlayed = 0;
        }
        
    }


    private void Update()
    {
        timeSinceLastPlayed += Time.deltaTime;
    }
}