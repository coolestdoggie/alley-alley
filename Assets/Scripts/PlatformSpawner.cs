using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private int amountPlatformsOnStart = 6;
    [SerializeField] private Vector2 offset;

    void Start()
    {
        SpawnStartPlatforms();
    }

    void Update()
    {
        
    }

    public void SpawnStartPlatforms()
    {
        Vector2 pos = new Vector2(0, -3.6f);

        for (int i = 0; i < amountPlatformsOnStart; i++)
        {
            GameObject pooledItem = ObjectPooler.SharedInstance.GetPooledObject(Random.Range(0, 5));
            pooledItem.SetActive(true);
            pooledItem.transform.position = pos;

            pos += offset;
        }
    }
}
