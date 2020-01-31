using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    public static Fade instance;
    public Animator animator;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(this);

        
    }
    public void FadeIn(float speed, float delay)
    {
        StartCoroutine(FadeInRoutine(speed, delay));
    }

    public void FadeOut(float speed, float delay)
    {
        StartCoroutine(FadeOutRoutine(speed, delay));

    }
    public IEnumerator FadeInRoutine(float speed, float delay)
    {
        yield return new WaitForSeconds(delay);
        animator.SetTrigger("FadeIn");
        animator.speed = speed;
    }

    public IEnumerator FadeOutRoutine(float speed, float delay)
    {
        yield return new WaitForSeconds(delay);
        animator.SetTrigger("FadeOut");
        animator.speed = speed;
    }

}
