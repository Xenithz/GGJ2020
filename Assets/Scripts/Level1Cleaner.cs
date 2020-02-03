using System.Collections;
using Level2;
using UnityEngine;
using UnityEngine.Playables;

public class Level1Cleaner : MonoBehaviour
{
    public Light level1Light;
    public Light level2Light;
    public float timeToLerp = 2f;

    public AudioSource audiosource;

    public AudioClip becomingTheI;
    public AudioClip level2atmosphere;
    public AudioClip becomingTheISoundTrack;
    

    public void UncheckLevel1Collision()
    {
        TextEffect3D.level1Collision = false;
    }

    private IEnumerator LerpLevel2Light()
    {
        float percCompleted = 0f;
        float timeSinceStarted = Time.time;
        float timeRemaining = 0f;

        float level1LightStartValue = level1Light.intensity;


        while (percCompleted < 1f)
        {
            timeRemaining = Time.time - timeSinceStarted;
            percCompleted = timeRemaining / timeToLerp;
            level1Light.intensity = Mathf.Lerp(level1LightStartValue, 0, percCompleted);
            level2Light.intensity = Mathf.Lerp(0, 1, percCompleted);
            yield return null;
        }
    }


    public void PlayAtmosphereAudio()
    {
        StartCoroutine(PlayAtmosphereRoutine());
    }


    IEnumerator PlayAtmosphereRoutine()
    {
        audiosource.Stop();
        audiosource.PlayOneShot(becomingTheI);
        audiosource.PlayOneShot(becomingTheISoundTrack);
        yield return new WaitForSeconds(becomingTheISoundTrack.length);
        audiosource.loop = true;
        audiosource.clip=level2atmosphere;
        audiosource.volume = 0.2f;
        audiosource.Play();
    }
    
    
    public void ShowLevel2Light()
    {
        StartCoroutine(LerpLevel2Light());
    }
}