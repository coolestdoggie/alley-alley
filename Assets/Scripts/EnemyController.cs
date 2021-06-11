using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] Moving moving;

    private void Start()
    {
        moving?.SetUpMoveBoundaries();
    }

    void FixedUpdate()
    {

        moving?.Move();

    }

}
