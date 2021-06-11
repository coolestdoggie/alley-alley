using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayMoveStrategy : MonoBehaviour, IMoveStrategy
{

    [SerializeField] Moving moving;
    [SerializeField] float speed = 40f;
    [Range(0, .3f)]
    [SerializeField] float movementSmoothing = .05f;
    [SerializeField] float timeDelay = 3f;

    Rigidbody2D rgbd2D;
    Vector3 velocity = Vector3.zero;

    public float Speed { get => speed; set => speed = value; }

    private void Awake()
    {
        rgbd2D = GetComponent<Rigidbody2D>();
    }
    
    public void Move()
    {
        float move = speed * Time.deltaTime;
        Vector3 targetVelocity = new Vector2(move, rgbd2D.velocity.y);
        rgbd2D.velocity = Vector3.SmoothDamp(rgbd2D.velocity, targetVelocity, ref velocity, movementSmoothing);
        if (transform.position.x > 3.5f)
        {
            StartCoroutine(RepositionEnemy());
        }
    }

    IEnumerator RepositionEnemy()
    {
        Debug.Log("WARNING");
        yield return new WaitForSeconds(timeDelay);
        transform.position = new Vector2(-3.5f, transform.position.y);
    }

}
