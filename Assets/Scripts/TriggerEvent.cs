using UnityEngine;
using UnityEngine.Events;

public class TriggerEvent : MonoBehaviour
{
    public UnityEvent events;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            events.Invoke();
        }
    }
}