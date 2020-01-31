using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform groundChecker;
    public LayerMask groundLayer;
    public float groundRaycastDistance;
    public bool topDown = false;
    public float maxSpeed;
    public float accelerationSpeed;
    public Vector2 jumpForce;
    [SerializeField] private float gravityScale;

    [Header("Animator Variables")]
    public Animator animator;
    private bool isIdle;
    private bool isWalking;

    private Rigidbody rb;
    private float xAxis;
    private float yAxis;
    private bool jump;
    private bool isGrounded;
    private bool landed = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Debug.Log("Ground: " + isGrounded);

        if (topDown)
            MoveTopDown();
        else
            Move2D();

        Vector3 newVelocity = rb.velocity;
        newVelocity.y -= gravityScale * Time.fixedDeltaTime;
        rb.velocity = newVelocity;
    }

    private void Update()
    {
        //Debug.DrawRay(groundChecker.position, Vector3.down * groundRaycastDistance, Color.red, 0.3f);
        isGrounded = Physics.Raycast(groundChecker.position, Vector3.down, groundRaycastDistance, groundLayer);

        if (isGrounded && !landed)
        {
            animator.SetBool("Landing", true);
        }
        else
            animator.SetBool("Landing", false);


        xAxis = Input.GetAxisRaw("Horizontal");
        yAxis = Input.GetAxisRaw("Vertical");
        jump = Input.GetButtonDown("Jump");

        isIdle = !isWalking;

        animator.SetBool("isIdle", isIdle);
        animator.SetBool("isWalking", isWalking);

        if (jump)
            Jump();

    }

    void Move2D()
    {
        //rb.constraints = RigidbodyConstraints.FreezePositionZ;

        if (xAxis == 0)
        {
            Vector3 finaVelocity;
            finaVelocity = rb.velocity;
            finaVelocity.x = 0f;
            rb.velocity = finaVelocity;
            isWalking = false;
        }
        else
        {
            isWalking = true;
        }

        rb.velocity += new Vector3(xAxis, 0f, 0f) * accelerationSpeed;
        rb.velocity = new Vector3( Mathf.Clamp(rb.velocity.x, -maxSpeed,maxSpeed),rb.velocity.y,rb.velocity.z);
    }

    void MoveTopDown()
    {
        rb.constraints = RigidbodyConstraints.None;

        if (xAxis == 0 || yAxis == 0)
        {
            Vector3 finaVelocity;
            finaVelocity = rb.velocity;
            finaVelocity.x = 0f;
            finaVelocity.z = 0f;
            rb.velocity = finaVelocity;
        }

        rb.velocity += new Vector3(xAxis, 0f, yAxis) * accelerationSpeed;
        rb.velocity = new Vector3(Mathf.Clamp(rb.velocity.x, -maxSpeed, maxSpeed), rb.velocity.y, Mathf.Clamp(rb.velocity.z, -maxSpeed, maxSpeed));

        Debug.Log("VEL: " + rb.velocity);

    }

    void Jump()
    {
        if(isGrounded)
        {
            animator.SetTrigger("Jump");
            //rb.AddForce(new Vector3(jumpForce.x, jumpForce.y, 0f), ForceMode.Impulse);
            rb.velocity += new Vector3(jumpForce.x, jumpForce.y, 0f);

            Debug.Log("Jump");
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (!isGrounded && collision.collider.CompareTag("Ground"))
    //    {
    //        animator.SetBool("Landed", true);
    //        isGrounded = true;
    //    }
    //    else
    //    {
    //        animator.SetBool("Landed", false);
    //    }
    //}

    //private void OnCollisionExit(Collision collision)
    //{
    //    if (collision.collider.CompareTag("Ground"))
    //        isGrounded = false;
    //}
}
