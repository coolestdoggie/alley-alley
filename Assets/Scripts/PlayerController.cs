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
    [SerializeField] Jumping jumping;

    private float horizontalMove;
    private Sides side = Sides.Right;

    private void Start()
    {
        moving.SetUpMoveBoundaries();
    }

    void Update()
    {

        horizontalMove = moving.RunSpeed;

        moving.Move(horizontalMove * (int)side * Time.fixedDeltaTime);
        jumping.Jump();

        CheckForChangeDirection();
    }

    void FixedUpdate()
    {
        

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
