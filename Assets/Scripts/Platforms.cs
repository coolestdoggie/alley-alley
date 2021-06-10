using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforms : MonoBehaviour
{
    [SerializeField] GameObject enemy;


    private void Start()
    {
        enemy.transform.position = new Vector2(Random.Range(-3, 3), enemy.transform.position.y);
    }
}
