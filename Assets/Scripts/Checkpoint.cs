using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public enum Phase { TWO_D, TOP_DOWN, THIRD_PERSON, FIRST_PERSON };
    public Phase currentCheckpoint;


    private void OnApplicationQuit()
    {
        PlayerPrefs.SetString("lastCheckpoint", null);

    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerPrefs.SetString("lastCheckpoint", currentCheckpoint.ToString());
    }
}
