using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManage : MonoBehaviour
{
    public GameScore gameScore;
    public EnemySpawner enemySpawn;

    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1) 
        {
            Debug.Log("Loading Level StartLevel1Spawning");

            enemySpawn.StartLevel1Spawning();
        }
        else if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            Debug.Log("Loading Level StartLevel2Spawning");

            enemySpawn.StartLevel2Spawning();
        }
        else if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            Debug.Log("Loading Level StartLevel3Spawning");

            enemySpawn.StartLevel3Spawning();
        }
    }

    void Update()
    {

    }
   
}
