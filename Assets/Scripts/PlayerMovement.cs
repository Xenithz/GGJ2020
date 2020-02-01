using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [Header("Player Settings")]
    public bool topDown;
    public float accelerationSpeed;
    public float maxSpeed;
    public Vector2 jumpForce;
    [SerializeField] private float gravityScale;

    [Header("Animator Variables")]
    public Animator animator;

    [Header("Ground Settings")]
    public Transform groundChecker;
    public LayerMask groundLayer;
    public float groundRaycastDistance;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip[] footStepAudio;
    public AudioClip jumpClip;
    public AudioClip landClip;

    [SerializeField]private bool isGrounded;
    private bool isIdle;
    private bool isWalking;
    private bool jump;
    private bool landed = false;

    private Rigidbody rb;
    private float xAxis;
    private float yAxis;
    public LayerMask pillerLayer;
    public LayerMask wallLayer;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {

        if (topDown)
            MoveTopDown();
        else
            Move2D();
        RaycastHit hit;
        bool pillarFound = false;
        bool WallFound = false;
        if (Physics.Raycast(transform.position, GetCurrentDirection(), out hit, 1.5f, pillerLayer))
        {
            if (hit.transform.CompareTag("Pillar"))
                pillarFound = true;

        }
        if (Physics.Raycast(transform.position, GetCurrentDirection(), out hit, 4f, wallLayer))
        {
            if (hit.transform.CompareTag("Wall"))
                WallFound = true;

        }
        if (WallFound && pillarFound)
        {

            xAxis = yAxis = 0f;
            WallFound = pillarFound = false;
        }

        Vector3 newVelocity = rb.velocity;
        newVelocity.y -= gravityScale * Time.fixedDeltaTime;
        rb.velocity = newVelocity;
    }


    private void Update()
    {
        //Debug.DrawRay(groundChecker.position, Vector3.down * groundRaycastDistance, Color.red, 0.3f);
        isGrounded = Physics.Raycast(groundChecker.position, Vector3.down, groundRaycastDistance, groundLayer);

        if (isGrounded && !landed && rb.velocity.y < 0f)
        {
            landed = true;
            animator.SetBool("Landing", true);
            audioSource.PlayOneShot(landClip);
            //Debug.Log("grounded");
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

    public Vector3 GetCurrentDirection()
    {
        return new Vector3(xAxis, 0f, yAxis);
    }

    private void Move2D()
    {
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
        rb.velocity = new Vector3(Mathf.Clamp(rb.velocity.x, -maxSpeed, maxSpeed), rb.velocity.y, rb.velocity.z);
    }

    private void MoveTopDown()
    {
        // if(xAxis <= 0f && yAxis <= 0f)
        //     return;

        if (xAxis == 0 || yAxis == 0)
        {
            Vector3 finaVelocity;
            finaVelocity = rb.velocity;
            finaVelocity.x = 0f;
            finaVelocity.z = 0f;
            rb.velocity = finaVelocity;
        }

        rb.velocity += new Vector3(xAxis, 0f, yAxis) * accelerationSpeed;
        rb.velocity = new Vector3(Mathf.Clamp(rb.velocity.x, -maxSpeed, maxSpeed), rb.velocity.y,
            Mathf.Clamp(rb.velocity.z, -maxSpeed, maxSpeed));
    }

    private void Jump()
    {
        if (isGrounded)
        {
            landed = false;
            animator.SetTrigger("Jump");
            //rb.AddForce(new Vector3(jumpForce.x, jumpForce.y, 0f), ForceMode.Impulse);
            rb.velocity += new Vector3(jumpForce.x, jumpForce.y, 0f);
            audioSource.PlayOneShot(jumpClip);
        }
    }
   
}