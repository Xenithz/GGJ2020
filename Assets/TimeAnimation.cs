using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeAnimation : MonoBehaviour
{
    public Animator foxAnimator;
    public bool leapOfFaith;
    public Camera foxCam;
    public LayerMask mainCamLayers;
    //public TextEffect3D leapOfFaithText;

    [Header("Audio")]
    public AudioClip blackAndWhiteMusic;
    public AudioClip colorMusic;
    public AudioClip blackAndWhitefootsteps;
    public AudioClip colorfootsteps;
    public AudioClip jumpSound;

    private AudioSource blackAndWhiteSource;


    public void ChangeTime(float speed)
    {
        Time.timeScale = speed;
    }

    private void Start()
    {
        AudioManager.instance.PlayClip(blackAndWhiteMusic, 0.5f);
        AudioManager.instance.PlayClip(blackAndWhitefootsteps, 0.5f, 0.1f);

    }

    private void Update()
    {
        if (leapOfFaith)
        {
            if (Input.GetButtonDown("Jump"))
            {
                foxCam.cullingMask = mainCamLayers;
                ChangeTime(1f);
                ChangeClippingPlaneImmediate(10f);
                StartCoroutine(ChangeCamClippingPlane(10000f, 3f, 1f));
                AudioManager.instance.PlayClip(colorMusic, 0.2f);
                AudioManager.instance.PlayClip(colorfootsteps, 0.4f , 0.1f);
                Jump();
                leapOfFaith = false;
            }
        }

    }

    public void Jump()
    {
        AudioManager.instance.PlayClip(jumpSound, 0f);
    }

    public void ActivateLeapOfFaithBool()
    {
        leapOfFaith = true;
    }

    public void ToIdle()
    {
        foxAnimator.SetTrigger("To_idle");
    }

    public void ToJump()
    {
        foxAnimator.SetTrigger("To_Jump");

    }
    public void ToIdleWa()
    {
        foxAnimator.SetTrigger("To_IdleWa");

    }
    public void ToSpin()
    {
        foxAnimator.SetTrigger("To_spin");

    }
    // public void ActivateLeapOfFaithText()
    // {
    //     leapOfFaithText.NormalFadeIn();
    //
    // }

    private void ChangeClippingPlaneImmediate(float view)
    {
        foxCam.farClipPlane = view;

    }

    private IEnumerator ChangeCamClippingPlane(float view, float timeToComplete, float delay)
    {
        yield return new WaitForSeconds(delay);
        float speed = view / timeToComplete;

        while(foxCam.farClipPlane < view)
        {
            foxCam.farClipPlane += speed * Time.deltaTime;
            yield return null;
        }
    }

    

    //private IEnumerator FadeInLeapOfFaithText(float to, float timeToAppear)
    //{
    //    float speed = to / timeToAppear;

    //    while (foxCam.farClipPlane < view)
    //    {
    //        foxCam.farClipPlane += speed * Time.deltaTime;
    //        yield return null;
    //    }
    //}
}
