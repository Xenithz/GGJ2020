using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaControl : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector2 axis;
    [SerializeField] private float speed;
  
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        axis.x = Input.GetAxisRaw("Horizontal");
        axis.y = Input.GetAxisRaw("Vertical");
        transform.Translate(axis*speed*Time.deltaTime);

    }

  
}
