using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Moving moving;
    [SerializeField] Jumping jumping;


    private void Start()
    {
        moving?.SetUpMoveBoundaries();
    }

    void FixedUpdate()
    {
        
        moving?.Move();

    }

    void Update()
    {
        jumping?.Jump();

    }


}
