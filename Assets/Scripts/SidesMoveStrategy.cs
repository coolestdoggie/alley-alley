using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SidesMoveStrategy : MonoBehaviour, IMoveStrategy
{
    [SerializeField] Moving moving;
    [SerializeField] float speed = 40f;
    [SerializeField] [Range(0, .3f)] float movementSmoothing = .05f;

    Rigidbody2D rgbd2D;
    Sides side = Sides.Right;
    Vector3 velocity = Vector3.zero;
    bool isFacingRight = true;


    public float Speed { get => speed; set => speed = value; }

    private void Awake()
    {
        rgbd2D = GetComponent<Rigidbody2D>();
    }

    public void Move()
    {
        float move = speed * (int)side * Time.deltaTime;
        Vector3 targetVelocity = new Vector2(move, rgbd2D.velocity.y);
        rgbd2D.velocity = Vector3.SmoothDamp(rgbd2D.velocity, targetVelocity, ref velocity, movementSmoothing);

        CheckForChangeDirection();

        if (move > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (move < 0 && isFacingRight)
        {
            Flip();
        }

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
    
    private void Flip()
    {
        isFacingRight = !isFacingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
