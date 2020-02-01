using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text5 : MonoBehaviour
{

    public Color endColor;
    public float timeToLerp;

    public MeshRenderer[] meshRenderers;
    

    
    public void ChangeColor(float timeBeforeChanging)
    {
        foreach (MeshRenderer meshRenderer in meshRenderers)
        {
            StartCoroutine(ChangeColorRoutine(meshRenderer, timeBeforeChanging));
        }
    }
    
    
    private IEnumerator ChangeColorRoutine(MeshRenderer meshRenderer, float time)
    {
        yield return new WaitForSeconds(time);
        float percCompleted = 0f;
        float timeSinceStarted = Time.time;
        float timeRemaining = 0f;
        var startColor = meshRenderer.material.color;

        while (percCompleted < 1f)
        {
            timeRemaining = Time.time - timeSinceStarted;
            percCompleted = timeRemaining / timeToLerp;
            meshRenderer.material.color = Color.Lerp(startColor, endColor, percCompleted);
            meshRenderer.material.SetColor("_EmissionColor", meshRenderer.material.color);
            yield return null;
        }
    }
}
