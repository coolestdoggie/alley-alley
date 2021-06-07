using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    enum Sides
    {
        Left = -1,
        Right = 1
    }

    [SerializeField] Moving moving;
    [SerializeField] Animator animator;
    [SerializeField] float runSpeed = 40f;

    private float horizontalMove;
    private bool jump = false;
    private Sides side = Sides.Right;

    private void Start()
    {
        moving.SetUpMoveBoundaries();
    }

    void Update()
    {

        horizontalMove = runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", jump);
        }

        CheckForChangeDirection();
    }

    void FixedUpdate()
    {
        moving.Move(horizontalMove * (int)side * Time.fixedDeltaTime, jump);
        
        jump = false;
        animator.SetBool("IsJumping", jump);
    }

    private void CheckForChangeDirection()
    {
        if (transform.position.x > moving.Padding)
        {
            side = Sides.Left;
        }
        else if (transform.position.x < -moving.Padding)
        {
            side = Sides.Right;
        }
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