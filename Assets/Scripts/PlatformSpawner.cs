using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] int amountPlatformsOnStart = 6;
    [SerializeField] Vector2 offset;
    [SerializeField] Vector2 pos = new Vector2(0, -3.6f);

    public int AmountPlatformsOnStart { get => amountPlatformsOnStart; set => amountPlatformsOnStart = value; }
    public Vector2 Offset { get => offset; set => offset = value; }


    private void OnEnable()
    {
        Platforms.PlatformDisappeared += SpawnNextPlatform;
    }

    private void OnDisable()
    {
        Platforms.PlatformDisappeared -= SpawnNextPlatform;
    }

    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            SpawnUsualPlatform();
        }
        SpawnStartPlatforms();
    }

    private void SpawnStartPlatforms()
    {
        for (int i = 0; i < AmountPlatformsOnStart; i++)
        {
            SpawnNextPlatform();
        }
    }

    private void SpawnNextPlatform()
    {
        GameObject pooledItem = ObjectPooler.SharedInstance.GetPooledObject(Random.Range(0, 5));
        pooledItem.SetActive(true);
        pooledItem.transform.position = pos;

        pos += Offset;
    }

    private void SpawnUsualPlatform()
    {
        GameObject pooledItem = ObjectPooler.SharedInstance.GetPooledObject(0);
        pooledItem.SetActive(true);
        pooledItem.transform.position = pos;

        pos += Offset;
    }

    
}
