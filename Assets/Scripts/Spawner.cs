using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;

    public bool stopSpawning;
    public float spawnTime;
    public static float spawnDelay;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("BeginSpawn", spawnTime,spawnDelay);
    }

    // Update is called once per frame

    private void SpawnObject()
    {
    
            int randEnemy = Random.Range(0, enemyPrefabs.Length);
            int randSpawnPoint = Random.Range(0, spawnPoints.Length);

            Instantiate(enemyPrefabs[randEnemy], spawnPoints[randSpawnPoint].position, transform.rotation);
        
    }

    private void BeginSpawn()
    {
        SpawnObject();

        if (stopSpawning)
        {
            CancelInvoke("BeginSpawn");
        }
    }
}
