using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProblemText : MonoBehaviour
{

    public MeshRenderer[] meshRenderers;


    public void EnableProblemText()
    {
        foreach (MeshRenderer meshRenderer in meshRenderers)
        {
            meshRenderer.enabled = true;
        }
    }
    
    
    
}
