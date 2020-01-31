using System;
using System.Collections;
using UnityEngine;

public class Pillar : MonoBehaviour
{
    private float elapsedTime;
    [SerializeField] private Coroutine movementRoutine;
    [SerializeField] private float movementSpeed;
    [SerializeField] private PlayerMovement player;

    private bool isOnCollision;
    
    // Start is called before the first frame update
    [SerializeField] private float unitsToMove;
    private Coroutine pushRoutine;
    private void Start()
    {
    }

    // Update is called once per frame

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Colliding");
        if (other.transform.CompareTag("Player")&&!isOnCollision)
        {
            isOnCollision = true;
            Rigidbody rb = other.transform.GetComponent<Rigidbody>();
            Vector3 playersDirection = other.transform.GetComponent<PlayerMovement>().GetCurrentDirection();
            //GetComponent<Rigidbody>().isKinematic = true;
             StartCoroutine(Push(playersDirection));
            
        }
    }

   

    private IEnumerator Push(Vector3 directionToMove)
    {
        Vector3 startPostion = transform.position;
        Vector3 endPosition = startPostion + unitsToMove * directionToMove;
        while (Vector3.Distance(transform.position, endPosition) > 0.1f)
        {
            transform.Translate(directionToMove * (movementSpeed * Time.deltaTime));
            yield return null;
        }

        transform.position = endPosition;
        isOnCollision = false;

        yield return null;
    }
}