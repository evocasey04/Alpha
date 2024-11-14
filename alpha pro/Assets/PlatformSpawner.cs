using UnityEngine;
using System.Collections.Generic;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab; // Assign platform prefab here
    public Transform player; // Assign player transform here
    public float spawnDistance = 10f; // Distance ahead to spawn
    public int platformPoolSize = 5; // Number of platforms to pool
    private Queue<GameObject> platformPool;

    void Start()
    {
        platformPool = new Queue<GameObject>();
        for (int i = 0; i < platformPoolSize; i++)
        {
            GameObject platform = Instantiate(platformPrefab);
            platform.SetActive(false);
            platformPool.Enqueue(platform);
        }
        SpawnPlatform();
    }

    void Update()
    {
        if (player.position.x + spawnDistance > GetFurthestPlatformPosition())
        {
            SpawnPlatform();
        }
    }

    void SpawnPlatform()
    {
        GameObject platform = platformPool.Dequeue();
        platform.SetActive(true);
        platform.transform.position = new Vector3(player.position.x + spawnDistance, Random.Range(-2f, 2f), 0);
        platformPool.Enqueue(platform);
    }

    float GetFurthestPlatformPosition()
    {
        float maxX = 0;
        foreach (var platform in platformPool)
        {
            if (platform.activeInHierarchy)
                maxX = Mathf.Max(maxX, platform.transform.position.x);
        }
        return maxX;
    }
}

