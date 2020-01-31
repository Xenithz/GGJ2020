using UnityEngine;
using UnityEngine.Playables;

public class SwitchCameraToPlayer : MonoBehaviour
{
    public PlayableDirector playableDirector;

    public GameObject followCam;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playableDirector.Play();
            followCam.SetActive(false);
            this.gameObject.SetActive(false);

        }
    }
}