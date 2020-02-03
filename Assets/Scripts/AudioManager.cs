using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;


// Use the following 3 enum types to update the clip names
public enum SfxClip
{

};
public enum BgClip
{

   
};
public enum AudioTypes
{

  
};
//#singleton
public class AudioManager : MonoBehaviour
{


    public static AudioManager instance;

    public int maxPoolSize=10;
    public int defaultSize=5;

  
    private static List<AudioSource> sources;

    void Awake ()
    {
        sources = new List<AudioSource>();

        for (int i = 0; i< defaultSize; i++)
        {
            CreateSources(i);
    
        }
        if (!instance)
            instance = this;
        else if (instance != this)
            Destroy(this);



    }
    public void RevokeAllCommands()
    {

        StopAllCoroutines();
    }
    private AudioSource CreateSources(int index)
    {

        GameObject sourceObj = new GameObject("Audio" + index, typeof(AudioSource));
        sourceObj.transform.SetParent(this.gameObject.transform);
        var audioSource = sourceObj.GetComponent<AudioSource>();
        sources.Add(audioSource);
        return audioSource;

    }

    public void PlayClip(AudioClip clip, float delay)
    {
        StartCoroutine(Play(clip,delay));

    }
    public void PlayClip(AudioClip clip, float delay, float volume)
    {
        StartCoroutine(Play(clip,delay, volume));

    }

    private IEnumerator StopSource(AudioSource source, float delay)
    {
        yield return new WaitForSeconds(delay);
        source.Stop();
    }
    public void FadeOutClip(BgClip clipName,float delay, float time =1f)
    {
        var data = sources.Find(element => element.clip.name.ToLower().Contains(clipName.ToString().ToLower()));
        if (data != null)
            StartCoroutine(FadeClip(data,delay, time));


    }
    IEnumerator FadeClip(AudioSource source, float delay, float time)
    {

        yield return new WaitForSeconds(delay);
            time = 1f / time;
            while (source.volume >= 0f)
            {

                source.volume -= time * Time.deltaTime;
                yield return null;

            }
            source.Stop();
            source.volume = 1f;
     
       
    }
   
    IEnumerator FadeInClip(AudioSource source)
    {
     

        float speed= 0.1f;
        source.volume = 0f;
       
        source.Play();
        while (source.volume <= 1f)
        {

            source.volume += speed * Time.deltaTime;
            yield return null;

        }
        source.volume = 1f;
    

    }
   

    
    IEnumerator Play(AudioClip clip, float delay,bool isLooping = false,bool waitOnFade =false)
    {
        yield return new WaitForSeconds(delay);
        Debug.Log(clip.name + ", " + delay);
        AudioSource selectedSource=null;
        foreach (AudioSource source in sources)
        {

            if(!source.isPlaying&&!waitOnFade)
            {
                source.clip = clip;
                selectedSource = source;
                break;
            }

        }
        if (!selectedSource)
        {
            if (sources.Count < maxPoolSize)
            {
                selectedSource = CreateSources(sources.Count);
                selectedSource.clip = clip;
            }
            else
                Debug.Log("Max pool size reached");
        }
        selectedSource.loop = isLooping;
        if (!waitOnFade)
            selectedSource.Play();
        else
            StartCoroutine(FadeInClip(selectedSource));
        selectedSource.playOnAwake = false;
      
    }
    
    IEnumerator Play(AudioClip clip, float delay, float volume,bool isLooping = false,bool waitOnFade =false)
    {
        yield return new WaitForSeconds(delay);
        Debug.Log(clip.name + ", " + delay);
        AudioSource selectedSource=null;
        foreach (AudioSource source in sources)
        {

            if(!source.isPlaying&&!waitOnFade)
            {
                source.clip = clip;
                selectedSource = source;
                break;
            }

        }
        if (!selectedSource)
        {
            if (sources.Count < maxPoolSize)
            {
                selectedSource = CreateSources(sources.Count);
                selectedSource.clip = clip;
            }
            else
                Debug.Log("Max pool size reached");
        }
        selectedSource.loop = isLooping;
        if (!waitOnFade)
        {
            selectedSource.volume = volume;
            selectedSource.Play();
        }
        else
            StartCoroutine(FadeInClip(selectedSource));
        selectedSource.playOnAwake = false;
      
    }
}
