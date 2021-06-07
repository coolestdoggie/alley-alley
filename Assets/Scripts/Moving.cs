using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    [SerializeField] float jumpForce = 400f;                           
    [SerializeField] [Range(0, .3f)] float movementSmoothing = .05f;
    [SerializeField] LayerMask whatIsGround;                          
    [SerializeField] Transform groundCheck;                           
    [SerializeField] float padding = .1f;
    [SerializeField] float extraJumps;
    float leftJumps;
    private float xMin;
    private float xMax;
    private float yMin;
    private float yMax;

    const float groundedRadius = .2f; 
    private bool isGrounded;            
    private Rigidbody2D rgbd2D;
    private bool isFacingRight = true;  
    private Vector3 velocity = Vector3.zero;

    public float Padding { get => padding; set => padding = value; }

    private void Awake()
    {
        rgbd2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        isGrounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundedRadius, whatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
                isGrounded = true;
        }
    }

    public void Move(float move, bool jump)
    {
        if (isGrounded)
        {
            leftJumps = extraJumps;
            
        }




        Vector3 targetVelocity = new Vector2(move, rgbd2D.velocity.y);
        rgbd2D.velocity = Vector3.SmoothDamp(rgbd2D.velocity, targetVelocity, ref velocity, movementSmoothing);

        if (move > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (move < 0 && isFacingRight)
        {
            Flip();
        }


        if (isGrounded && jump)
        {
            isGrounded = false;
            rgbd2D.AddForce(new Vector2(0f, jumpForce));
        }
        else if (!isGrounded && jump && leftJumps > 0)
        {
            rgbd2D.velocity = Vector2.zero;
            rgbd2D.AddForce(new Vector2(0f, jumpForce));
            leftJumps--;
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;

        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + Padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - Padding;
    }
}
