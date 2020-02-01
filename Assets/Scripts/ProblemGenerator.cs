using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class ProblemGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> problemPatterns;
    public float timeBetweenPatterns = 1f;
    private int waveIndex;

    public GameObject boundary;
    public PlayableDirector resetToPlayerCam;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(StartProblemFall());
        }
    }

    private IEnumerator StartProblemFall()
    {
        while (waveIndex < problemPatterns.Count)
        {
            yield return new WaitForSeconds(1f);
            problemPatterns[waveIndex].SetActive(true);
            waveIndex++;
            yield return new WaitForSeconds(timeBetweenPatterns);
            

        }
        yield return new WaitForSeconds(15);
        ResetCamera();
    }


    void ResetCamera()
    {
        resetToPlayerCam.Play();
        boundary.SetActive(false);
    }
}