using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float accelerationSpeed;

    [Header("Animator Variables")] public Animator animator;


    public AudioSource audioSource;
    public Vector2 currentDirection;

    public AudioClip[] footStepAudio;
    [SerializeField] private float gravityScale;
    public Transform groundChecker;
    public LayerMask groundLayer;
    public float groundRaycastDistance;
    private bool isGrounded;
    private bool isIdle;
    private bool isWalking;
    private bool jump;
    public AudioClip jumpClip;
    public Vector2 jumpForce;
    public AudioClip landClip;
    private bool landed = false;
    public float maxSpeed;

    private Rigidbody rb;
    public bool topDown;
    private float xAxis;
    private float yAxis;

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
            animator.SetTrigger("Jump");
            rb.AddForce(new Vector3(jumpForce.x, jumpForce.y, 0f), ForceMode.Impulse);
            Debug.Log("Jump");
            audioSource.PlayOneShot(jumpClip);
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