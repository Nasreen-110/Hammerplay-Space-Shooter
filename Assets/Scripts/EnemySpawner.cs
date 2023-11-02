using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] level1AsteroidPrefabs;
    public GameObject level2EnemyShipPrefab;
    public GameObject[] level3EnemyPrefabs;

    private float maxSpawnDelay = 5f;
    float maxSpawn = 2f;

    void Start()
    {
        StartLevel();
    }

    void Update()
    {

    }
    public void StartLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            Debug.Log("Loading StartLevel1Spawning");

            StartLevel1Spawning();
            maxSpawnDelay = 5f;
        }
        else if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            Debug.Log("Loading StartLevel2Spawning");

            StartLevel2Spawning();
            maxSpawnDelay = 5f;
        }
        else if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            Debug.Log("Loading StartLevel3Spawning");

            StartLevel3Spawning();
            maxSpawnDelay = 3f;
        }
    }

    void SpawnLevel1Enemies()
    {
        Spawn(level1AsteroidPrefabs);

    }

    void SpawnLevel2Enemies()
    {
        EnemySpawn();
    }

    void SpawnLevel3Enemies()
    {
        Spawn(level3EnemyPrefabs);
    }

    void EnemySpawn()
    {
        Debug.Log("Loading EnemySpawn");

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        GameObject enemyship =(GameObject)Instantiate(level2EnemyShipPrefab);
        enemyship.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
        float EnemySpawnDelay = Random.Range(1f, maxSpawnDelay);
        CancelInvoke("EnemySpawn");
        Invoke("EnemySpawn", EnemySpawnDelay);
    }
    

    void Spawn(GameObject[] enemyPrefabs)
    {
        Debug.Log("Loading Spawn");

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

        GameObject enemy = Instantiate(enemyPrefab);
        enemy.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
    }

    public void StartLevel1Spawning()
    {
        maxSpawnDelay = 5f;
        InvokeRepeating("SpawnLevel1Enemies", 0f, maxSpawnDelay);
        InvokeRepeating("IncreaseSpawns", 0f, 20f);

    }

    public void StartLevel2Spawning()
    {
        maxSpawnDelay = 5f;
        InvokeRepeating("SpawnLevel2Enemies", 0f, maxSpawnDelay);
        InvokeRepeating("IncreaseSpawns", 0f, 20f);

    }

    public void StartLevel3Spawning()
    {
        maxSpawnDelay = 2f;
        InvokeRepeating("SpawnLevel3Enemies", 0f, maxSpawnDelay);
        InvokeRepeating("IncreaseSpawns", 0f, 5f);

    }

    public void StopEnemySpawner()
    {
        CancelInvoke("SpawnLevel1Enemies");
        CancelInvoke("SpawnLevel2Enemies");
        CancelInvoke("SpawnLevel3Enemies");
    }
    void IncreaseSpawns()
    {
        if (maxSpawn > 1f)
            maxSpawn--;
        if (maxSpawn == 1f)
            CancelInvoke("IncreaseSpawns");
    }

}
