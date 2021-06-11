using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Moving moving;
    [SerializeField] Jumping jumping;
    [SerializeField] LayerMask enemyLayer;

    Rigidbody2D rgb2d;
    Animator animator;

    private bool frozen = false;
    public static event Action GameOver;

    private void Awake()
    {
        rgb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        moving?.SetUpMoveBoundaries();
    }

    void FixedUpdate()
    {
        
        if (frozen == false)
        {
            moving?.Move();
        }
        else
        {
            rgb2d.velocity = Vector2.zero;
        }

    }

    void Update()
    {
        jumping?.Jump();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (1 << collision.gameObject.layer == enemyLayer.value)
        {
            animator.SetTrigger("Die");
            frozen = true;
            OnGameOver();
        }
    }

    private void OnGameOver()
    {
        GameOver?.Invoke();
    }
}
