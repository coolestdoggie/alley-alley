using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidesMoveStrategy : MonoBehaviour, IMoveStrategy
{
    enum Sides
    {
        Left = -1,
        Right = 1
    }

    Sides side = Sides.Right;
   // float horizontalMove;

    [SerializeField] Moving moving;
   // [SerializeField] float runSpeed = 40f;
    [SerializeField] [Range(0, .3f)] float movementSmoothing = .05f;
    

    Rigidbody2D rgbd2D;
    Vector3 velocity = Vector3.zero;

    public float Speed { get; set; }

    private void Start()
    {
        rgbd2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        //horizontalMove = moving.RunSpeed;
    }

    public void Move(float move)
    {
        if (transform.position.x > moving.Padding)
        {
            side = Sides.Left;
        }
        else if (transform.position.x < -moving.Padding)
        {
            side = Sides.Right;
        }

        Vector3 targetVelocity = new Vector2(move, rgbd2D.velocity.y);
        rgbd2D.velocity = Vector3.SmoothDamp(rgbd2D.velocity, targetVelocity, ref velocity, movementSmoothing);
    }


}
