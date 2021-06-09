using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayMoveStrategy : MonoBehaviour, IMoveStrategy
{

    [Range(0, .3f)]
    [SerializeField] float movementSmoothing = .05f;
    [SerializeField] float speed = 40f;


    Rigidbody2D rgbd2D;
    Vector3 velocity = Vector3.zero;

    public float Speed { get => speed; set => speed = value; }

    private void Awake()
    {
        rgbd2D = GetComponent<Rigidbody2D>();
    }

    public void Move()
    {
        //Vector3 targetVelocity = new Vector2(move, rgbd2D.velocity.y);
        //rgbd2D.velocity = Vector3.SmoothDamp(rgbd2D.velocity, targetVelocity, ref velocity, movementSmoothing);
    }


}
