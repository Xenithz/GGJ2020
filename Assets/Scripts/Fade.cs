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
    public void FadeIn(float speed)
    {
        animator.SetTrigger("FadeIn");
    }

    public void FadeOut(float speed)
    {
        animator.SetTrigger("FadeOut");

    }

}
