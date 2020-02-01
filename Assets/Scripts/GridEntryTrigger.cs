using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class GridEntryTrigger : MonoBehaviour
{
    // Start is called before the first frame update

    public UnityEvent onTriggerEnter;
    public UnityEvent delayedTriggerEnter;
    [SerializeField] float delayEnterTime;
    private void OnTriggerEnter(Collider other)
    {
        onTriggerEnter.Invoke();
        Invoke("DelayedEnter",delayEnterTime);
        
    }
    void DelayedEnter()
    {
        delayedTriggerEnter.Invoke();
    }
}
