using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PillarPivot : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isFilled;
    public static int score=0;
    
    private void OnDestroy()
    {
        score = 0;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Pillar") && !isFilled)
        {

            other.transform.GetComponent<Rigidbody>().isKinematic = true;
            other.transform.rotation = Quaternion.identity;
            other.transform.position = transform.position - Vector3.up * 1.39f;
            other.transform.GetComponent<MonoBehaviour>().StopAllCoroutines();
            AudioManager.instance.PlayClip(AudioClipReferences.instance.tileComepletedClip, 0f);
           ++score;
            isFilled = true;
            if (score >= 9)
            {
                AudioManager.instance.PlayClip(AudioClipReferences.instance.gridLevelSuccesfulAudio, 2f);
                GameManager.instance.BringUpPlatform();
                this.enabled = false;
            }
            Debug.Log(score);

        }
        else if (other.transform.CompareTag("Player") && !isFilled)
        {

            Fade.instance.FadeIn(1f, 0f);
            SceneManager.LoadScene(0);
        }
        //other.transform.position = new Vector3(transform.position.x - 8.2f, transform.position.z);

        //Invoke("SnapIn", 2f);
    }
    void SnapIn()
    {
        
        transform.rotation = Quaternion.identity;
        transform.position = new Vector3(transform.position.x - 8.2f, transform.position.z);
    }
}
