using System;
using System.Collections;
using UnityEngine;

public class BrokenText : MonoBehaviour
{
    public float timeToLerp = 2f;


    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    public void ScaleText()
    {
        StartCoroutine(ScaleBrokenText());
    }


    public IEnumerator ScaleBrokenText()
    {
        float percCompleted = 0f;
        float timeSinceStarted = Time.time;
        float timeRemaining = 0f;
        var startScale = transform.localScale;
        var endScale = new Vector3(0.5f, 0.5f, 0.5f);

        while (percCompleted < 1f)
        {
            timeRemaining = Time.time - timeSinceStarted;
            percCompleted = timeRemaining / timeToLerp;
            transform.localScale = Vector3.Lerp(startScale, endScale, percCompleted);
            yield return null;
        }

        rb.isKinematic = true;

    }
}