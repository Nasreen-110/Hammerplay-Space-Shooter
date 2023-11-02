using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject[] asteroidPrefabs;
    float maxspawn = 4f;

    public int randomIndex { get; private set; }

    void Start()
    {

    }

    void Update()
    {

    }
    void EnemySpawn()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        GameObject enemy1 = (GameObject)Instantiate(asteroidPrefabs[randomIndex]);
        enemy1.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
        NextEnemy();
    }
    void NextEnemy()
    {
        float spawnInSecond;
        if (maxspawn > 1f)
        {
            spawnInSecond = Random.Range(1f, maxspawn);
        }
        else
            spawnInSecond = 1f;
        Invoke("EnemySpawn", spawnInSecond);
    }
    void IncreaseSpawns()
    {
        if (maxspawn > 1f)
            maxspawn--;
        if (maxspawn == 1f)
            CancelInvoke("IncreaseSpawns");
    }
    public void StartEnemySpawner()
    {
        maxspawn = 5f;

        Invoke("EnemySpawn", maxspawn);

        InvokeRepeating("IncreaseSpawns", 0f, 20f);
    }

    public void StopEnemySpawner()
    {
        CancelInvoke("EnemySpawn");
        CancelInvoke("IncreaseSpawns");
    }
   
}
