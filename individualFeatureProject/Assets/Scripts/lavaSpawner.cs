using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lavaSpawner : MonoBehaviour
{
    public GameObject lavaPrefab;
    public Transform spawnPoint;
    public float spawnInterval = 2.0f;

    void Start()
    {
        // Start the lava spawning coroutine
        StartCoroutine(SpawnLava());
    }

    IEnumerator SpawnLava()
    {
        while (true)
        {
            // Instantiate a new lava object at the spawn point
            GameObject lavaInstance = Instantiate(lavaPrefab, spawnPoint.position, Quaternion.identity);

            // Wait for the specified spawn interval before spawning the next lava object
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}