using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    [SerializeField] float runSpeed = 40f;                          
    [SerializeField] float padding = .1f;

    private IMoveStrategy moveStrategy;

    private float xMin;
    private float xMax;
   
    private Rigidbody2D rgbd2D;
    private bool isFacingRight = true;  

    public float Padding { get => padding; set => padding = value; }
    public float RunSpeed { get => runSpeed; set => runSpeed = value; }

    private void Awake()
    {
        rgbd2D = GetComponent<Rigidbody2D>();
        moveStrategy = GetComponent<IMoveStrategy>();
    }



    public void Move(float move)
    {
        moveStrategy.Move(move);

 
        if (move > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (move < 0 && isFacingRight)
        {
            Flip();
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
