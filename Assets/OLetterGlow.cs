using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class OLetterGlow : MonoBehaviour
{
    Animator letterGlowAnimator;

    private void Start()
    {
        letterGlowAnimator = GetComponent<Animator>();
    }
    public void Activate()
    {
        letterGlowAnimator.SetTrigger("Glow");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Fade.instance.FadeOut(1f, 0.2f);
            StartCoroutine(LoadSceneInSeconds(0.5f));
        }
    }

    private IEnumerator LoadSceneInSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(1);
    }
}
