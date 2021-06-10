using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforms : MonoBehaviour
{
    [SerializeField] private int distanceToDelete = 5;
    PlayerController player;

    public static event Action PlatformDisappeared;


    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        RepositionPlatforms();
    }

    private void RepositionPlatforms()
    {

        if (player.transform.position.y > (transform.position.y + distanceToDelete))
        {
            gameObject.SetActive(false);
            OnPlatfromDisappeared();
        }
        
    }


    private void OnPlatfromDisappeared()
    {
        PlatformDisappeared?.Invoke();
    }
}
