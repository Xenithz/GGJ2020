using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockVibration : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 startPosition;
    Vector3 finalPosition;
    public float rotaionSpeed=2f;
    public bool rotationType;
    Vector3 rotaionDirection;
    public float rotationSpeed;
    private float vibrationMagnitude;
   
    void Start()
    {
        startPosition = transform.position;
        rotaionDirection = Random.insideUnitSphere;
        rotaionSpeed = Random.Range(15, 25f);
        vibrationMagnitude = Random.Range(0, 3);

    }

    // Update is called once per frame
    void Update()
    {
        if (rotationType)
        {
            transform.Rotate(rotaionDirection * rotaionSpeed*Time.deltaTime);
        }
        else
        {
            transform.position = startPosition+ Vector3.up * Mathf.Sin(Time.time*vibrationMagnitude);

        }
    }
}
