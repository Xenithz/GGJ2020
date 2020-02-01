using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioClipReferences : MonoBehaviour
{
    // Start is called before the first frame update
    public static AudioClipReferences instance;

    public AudioClip pushingClip;
    public AudioClip gridLevelSuccesfulAudio;
    public AudioClip tileComepletedClip;
    void Start()
    {
        if (!instance)
            instance = this;
        else if (instance != this)
            Destroy(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
