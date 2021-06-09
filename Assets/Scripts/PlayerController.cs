using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Moving moving;
    [SerializeField] Jumping jumping;


    private void Start()
    {
        moving?.SetUpMoveBoundaries();
    }

    void Update()
    {
        
        moving?.Move();
        jumping?.Jump();

    }

    
}
