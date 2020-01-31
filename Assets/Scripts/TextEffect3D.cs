using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextEffect3D : MonoBehaviour
{
    [SerializeField]private MeshRenderer[] renderers;
    [SerializeField] private Material textMat;
    [SerializeField] private float normalFadeTime;
    [SerializeField] private float perCharacterFadeTime;
    private Coroutine routine;
    private void Start()
    {
        for (int i = 0; i < renderers.Length; i++)
        {
            Material newMat = new Material(textMat);
            renderers[i].material = newMat;
        }

        //StartCoroutine(NormalFadeIn(5f));
        

        
    }
    private IEnumerator NormalFadeInRoutine()
    {
        float timer = 0f;
        float speed = 1f / normalFadeTime;

        while (renderers[0].material.color.a <1f)
        {
            for (int i = 0; i < renderers.Length; i++)
            {
                Color color = renderers[i].material.color;
                color.a += speed * Time.deltaTime;
                renderers[i].material.color = color;

            }
            yield return null;
        }
        routine = null;



    }
    public void  NormalFadeIn()
    {
    
        routine =  StartCoroutine(NormalFadeInRoutine());
    }
    public void NormalFadeOut()
    {
    
            routine = StartCoroutine(NormalFadeOutRoutine());
    }
    public void PerCharacterFadeIn()
    {
       
            routine = StartCoroutine(PerCharacterFadeInRoutine());
    }
    public void PerCharacterFadeOut()
    {
       
            routine = StartCoroutine(PerCharacterFadeOutRoutine());
    }


    private IEnumerator NormalFadeOutRoutine()
    {
        float timer = 0f;
        float speed = 1f / normalFadeTime;

        while (renderers[0].material.color.a > 0f)
        {
            for (int i = 0; i < renderers.Length; i++)
            {
                Color color = renderers[i].material.color;
                color.a -= speed * Time.deltaTime;
                renderers[i].material.color = color;

            }
            yield return null;
        }
        routine = null;


    }
    private IEnumerator PerCharacterFadeOutRoutine()
    {
        float speed = 1f / perCharacterFadeTime;
        int characterIndex = 0;
        while (characterIndex<renderers.Length)
        {
            Color color = renderers[characterIndex].material.color;

            while (color.a >=0f)
            {
                color.a -= speed * Time.deltaTime;
                renderers[characterIndex].material.color = color;
                yield return null;

            }
            color.a = 0f;
            renderers[characterIndex].material.color = color;
            characterIndex++;

        }
        routine = null;


    }
    private IEnumerator PerCharacterFadeInRoutine()
    {
        float totalTime = perCharacterFadeTime * renderers.Length;
        float speed = 1f / perCharacterFadeTime;
        int characterIndex = 0;
        while (characterIndex < renderers.Length)
        {
            Color color = renderers[characterIndex].material.color;

            while (color.a <= 1f)
            {
                color.a += speed * Time.deltaTime;
                renderers[characterIndex].material.color = color;
                yield return null;

            }
            color.a = 1f;
            renderers[characterIndex].material.color = color;
            characterIndex++;

        }
        routine = null;

    }

}
