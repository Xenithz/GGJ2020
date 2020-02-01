using System;
using System.Collections;
using UnityEngine;

public class LightControls : MonoBehaviour
{
    private Light light;

    public float timeToLerp = 1;


    private void Awake()
    {
        light = GetComponent<Light>();
    }

    private void Update()
    {
        light.intensity = Mathf.Clamp01(light.intensity);
    }

    public void DecreaseLight(float decreaseAmount)
    {
        StartCoroutine(DecreaseLightRoutine(decreaseAmount));
    }

    public void IncreaseLight(float increaseAmount)
    {
        StartCoroutine(IncreaseLightRoutine(increaseAmount));
    }


    private IEnumerator DecreaseLightRoutine(float amount)
    {
        float percCompleted = 0f;
        float timeSinceStarted = Time.time;
        float timeRemaining = 0f;
        var startIntensity = light.intensity;
        var endIntensity = light.intensity - amount;

        while (percCompleted < 1f)
        {
            timeRemaining = Time.time - timeSinceStarted;
            percCompleted = timeRemaining / timeToLerp;
            light.intensity = Mathf.Lerp(startIntensity, endIntensity, percCompleted);
            yield return null;
        }
    }
    private IEnumerator IncreaseLightRoutine(float amount)
    {
        float percCompleted = 0f;
        float timeSinceStarted = Time.time;
        float timeRemaining = 0f;
        var startIntensity = light.intensity;
        var endIntensity = light.intensity + amount;

        while (percCompleted < 1f)
        {
            timeRemaining = Time.time - timeSinceStarted;
            percCompleted = timeRemaining / timeToLerp;
            light.intensity = Mathf.Lerp(startIntensity, endIntensity, percCompleted);
            yield return null;
        }
    }
}