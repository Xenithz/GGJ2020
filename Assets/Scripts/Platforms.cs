using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Platforms : MonoBehaviour
{
    [SerializeField] private GameObject[] platforms;
    // Start is called before the first frame update
    [SerializeField] private float delayBetweenPlatforms;

    public UnityEvent platformEnterEvent;

    private void Start()
    {
     
    }

    public void OnPlatFormTrigger()
    {



        StartCoroutine(PlatformShow());

    }
    IEnumerator PlatformShow()
    {
        int platformIndex = 0;
        while (platformIndex<platforms.Length)
        {
            platforms[platformIndex].SetActive(true);

            ++platformIndex;
            yield return new WaitForSeconds(delayBetweenPlatforms);
        }

    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag("Player")&&PillarPivot.score>9)
        {

            platformEnterEvent.Invoke();
        }

    }
}
