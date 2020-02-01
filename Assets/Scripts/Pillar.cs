using System;
using System.Collections;
using UnityEngine;

public class Pillar : MonoBehaviour
{
    private float elapsedTime;
    [SerializeField] private Coroutine movementRoutine;
    [SerializeField] private float movementSpeed;
    [SerializeField] private PlayerMovement player;

    [SerializeField]private bool isOnCollision;
    
    // Start is called before the first frame update
    [SerializeField] private float unitsToMove;
    private Coroutine pushRoutine;
    public AudioClip pushingClip;
    private void Start()
    {
    }

    // Update is called once per frame

    private void OnCollisionEnter(Collision other)
    {
        //Debug.Log(other.transform.name);
        Debug.Log(other.transform.name);
        if (other.transform.CompareTag("Player") && !isOnCollision)
        {
            isOnCollision = true;

            Vector3 playersDirection = other.transform.GetComponent<PlayerMovement>().GetCurrentDirection();

            if(playersDirection.magnitude>0)
            pushRoutine= StartCoroutine(Push(playersDirection));
            AudioManager.instance.PlayClip(AudioClipReferences.instance.pushingClip, 0f);
         

        }
        
    }

   

    private IEnumerator Push(Vector3 directionToMove)
    {
        Vector3 startPostion = transform.position;
        Vector3 endPosition = startPostion + unitsToMove * directionToMove;
        Rigidbody rb = GetComponent<Rigidbody>();
   
        while (Vector3.Distance(transform.position, endPosition) > 0.1f)
        {
            //rb.velocity += directionToMove * 1.2f;
            //rb.velocity = Vector3.ClampMagnitude(rb.velocity, 1f);
            transform.Translate(directionToMove * (movementSpeed * Time.deltaTime),Space.World);
            yield return null;
        }
      
        transform.position = endPosition;
        isOnCollision = false;

        yield return null;
    }
}