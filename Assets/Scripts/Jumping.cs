using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    [Header("Jumping")]
    [SerializeField] float jumpForce = 400f;
    [SerializeField] float extraJumps;
    float leftJumps;
    bool jump = false;

    [Header("Grounding")]
    [SerializeField] LayerMask whatIsGround;
    [SerializeField] Transform groundCheck;
    const float groundedRadius = .2f;
    bool isGrounded;

    Rigidbody2D rgbd2D;

    public float LeftExtraJumps { get => leftJumps; set => leftJumps = value; }

    void Awake()
    {
        rgbd2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        jump = false;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }


        isGrounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundedRadius, whatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
                isGrounded = true;
        }
    }


    public void Jump()
    {
        if (isGrounded)
        {
            LeftExtraJumps = extraJumps;
        }
        if (isGrounded && jump)
        {
            rgbd2D.velocity = Vector2.zero;
            isGrounded = false;
            rgbd2D.AddForce(new Vector2(0f, jumpForce));
        }
        else if (!isGrounded && jump && LeftExtraJumps > 0)
        {
            rgbd2D.velocity = Vector2.zero;
            rgbd2D.AddForce(new Vector2(0f, jumpForce));
            LeftExtraJumps--;
        }
    }
    
}
