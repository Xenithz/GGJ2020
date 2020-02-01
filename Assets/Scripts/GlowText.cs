using System;
using UnityEditor;
using UnityEngine;

public class GlowText : MonoBehaviour
{
    public MeshRenderer[] characterMeshes;


    private void Start()
    {
        DisableGlow();
    }


    public void EnableGlow()
    {
        foreach (MeshRenderer characterMesh in characterMeshes)
        {
            characterMesh.enabled = true;
        }
    }

    public void DisableGlow()
    {
        foreach (MeshRenderer characterMesh in characterMeshes)
        {
            characterMesh.enabled = false;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        EnableGlow();
    }

    private void OnTriggerExit(Collider other)
    {
        DisableGlow();
    }
}