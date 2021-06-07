using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
//{
//    [Header("Moving")]
//    [SerializeField] private int speed = 10;
//    [SerializeField] private int jumpForce = 10;

//    [SerializeField] float moveSpeed = 10f;
//    [SerializeField] float padding = .1f;

//    private bool isFacingRight = true;

//    private Rigidbody2D rb2d;
//    private Animator animator;

//    private bool isGrounded;

//    float xMin;
//    float xMax;
//    float yMin;
//    float yMax;

//    private void Awake()
//    {
//        rb2d = GetComponent<Rigidbody2D>();
//        animator = GetComponent<Animator>();
//    }

//    private void Start()
//    {
//        SetUpMoveBoundaries();
//    }

//    void Update()
//    {
//        Move();

//        float hor = Input.GetAxis("Horizontal") * Time.deltaTime;

//        transform.Translate(hor * speed, 0, 0);

//        rb2d.velocity = new Vector2(hor * speed * Time.deltaTime, rb2d.velocity.y);

//        //if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
//        //{
//        //    rb2d.AddForce(new Vector2(0, jumpForce));
//        //}


//        //animator.SetBool("breakBrick", breakBrick);
//        //animator.SetBool("isGrounded", isGrounded);
//        //animator.SetFloat("vert", Mathf.Abs(rb2d.velocity.y));
//        //animator.SetFloat("hor", Mathf.Abs(hor));

//    private void SetUpMoveBoundaries()
//    {
//        Camera gameCamera = Camera.main;

//        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
//        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
//    }

//    private void Move()
//    {
//        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
//        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);

//        transform.position = new Vector2(newXPos, 0);

//    } 
//    private void OnCollisionEnter2D(Collision2D collision)
//    {
//        isGrounded = true;
//    }

//    private void OnCollisionExit2D(Collision2D collision)
//    {
//        isGrounded = false;
//    }



//}
{
   

    enum Sides
    {
        Left = -1,
        Right = 1
    }
    

    public Moving moving;
    public Animator animator;

    public float runSpeed = 40f;

    float horizontalMove;
    bool jump = false;
    bool crouch = false;
    
    private Sides side = Sides.Right;

    // Update is called once per frame
    void Update()
    {

        horizontalMove = runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", jump);
        }

        if (transform.position.x > 1.8f)
        {
            side = Sides.Left;
        }
        else if (transform.position.x < -1.8f)
        {
            side = Sides.Right;
        }

    }

    void FixedUpdate()
    {
        //Move our character
        

        moving.Move(horizontalMove * (int)side * Time.fixedDeltaTime, crouch, jump);
        
        jump = false;
        animator.SetBool("IsJumping", jump);
    }

}


//{
//    float littleJumpForce = 20;
//    float jumpForce = 60;
//    float maxJumpTime = 0.1f;
//    float defaultMaxJumpTime = 0.1f;
//    Collider2D myCollider;
//    LayerMask whatIsGround;
//    GameObject groundCheck;
//    bool isGround = false;
//    float groundRadius = 0.2f;
//    protected int extraJump = 0;
//    int defaultExtraJump = 1;
//    Rigidbody2D rb;
//    Animator animator;

//    protected int ExtraJump { get => extraJump; set => extraJump = value; }

//    private void Awake()
//    {
//        rb = gameObject.GetComponent<Rigidbody2D>();
//        myCollider = gameObject.GetComponent<Collider2D>();
//        whatIsGround = LayerMask.GetMask("Ground");
//        groundCheck = GameObject.Find("groundCheck");
//    }


//    public void CheckGround()
//    {
//        isGround = Physics2D.OverlapCircle(groundCheck.transform.position, groundRadius, whatIsGround);
//    }

//    public void Jump()
//    {
//        if (extraJump >= 0)
//        {
//            if (Input.GetKeyDown(KeyCode.UpArrow))
//            {
//                if (extraJump > 0)
//                {
//                    maxJumpTime = defaultMaxJumpTime;
//                    rb.AddForce(new Vector2(0, littleJumpForce), ForceMode2D.Impulse);
//                }
//                else if (extraJump == 0)
//                {
//                    maxJumpTime = defaultMaxJumpTime;
//                    rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
//                }
//            }
//            if (Input.GetKey(KeyCode.UpArrow) && maxJumpTime >= 0)
//            {
//                maxJumpTime -= Time.deltaTime * 4;
//                rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
//            }
//            if (Input.GetKeyUp(KeyCode.UpArrow) && !isGround)
//            {
//                extraJump--;
//            }
//        }
//        animator.SetBool("isGround", false);
//    }


//    void Start()
//    {
//        maxJumpTime = defaultMaxJumpTime;
//        extraJump = defaultExtraJump;
//    }

//    private void FixedUpdate()
//    {
//        Jump();
//        CheckGround();
//    }
//}