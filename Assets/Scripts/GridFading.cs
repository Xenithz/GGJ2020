using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridFading : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Renderer[] renderers;
    [SerializeField] private float blendTime;
    void Start()
    {
        SetGridObjectAlpha(0);
    }
    public void SetGridObjectAlpha(float alpha)
    {

        for (int i = 0; i < renderers.Length; i++)
        {
            Color col = renderers[i].material.color;
            col.a = alpha;
            renderers[i].material.color = col;

        }
    }
    public void BlendInObjects()
    {

        StartCoroutine(BlendInRoutine());
    }
    IEnumerator BlendInRoutine()
    {

        int currentObjectIndex = 0;
        float speed = 1f / blendTime;
        while (currentObjectIndex < renderers.Length)
        {
            Color col = renderers[currentObjectIndex].material.color;
            while (col.a < 1f)
            {
                col.a += speed * Time.deltaTime;
                renderers[currentObjectIndex].material.color = col;
                yield return null;

            }

            ++currentObjectIndex;
            Debug.Log(currentObjectIndex);
        }
        

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
