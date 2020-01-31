using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProblemGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> problemPatterns;
    public float timeBetweenPatterns = 1f;
    private bool problemTriggered = false;
    private float timeLastSpawned;
    private int waveIndex = 0;
    private void Update()
    {
        if(problemTriggered)
        {
            if (waveIndex > problemPatterns.Count - 1)
                problemTriggered = false;
            if (Time.time > timeLastSpawned + timeBetweenPatterns)
            {
                problemPatterns[waveIndex].SetActive(true);
                timeLastSpawned = Time.time;
                waveIndex++;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
            problemTriggered = true;
    }

    private IEnumerator StartProblemFall()
    {
        yield return new WaitForSeconds(timeBetweenPatterns);
    }
}
