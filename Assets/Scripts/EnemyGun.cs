using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    public GameObject Enemybullet;

    void Start()
    {
        Invoke("ShootEnemyBullets", 1f);
    }

    void Update()
    {
        
    }

    void ShootEnemyBullets()
    {
        GameObject playership = GameObject.Find ("Playership");
        if (playership != null )
        {
            GameObject bullet = (GameObject)Instantiate(Enemybullet);
            bullet.transform.position = transform.position;
            Vector2 direction = playership.transform.position - bullet.transform.position;
            bullet.GetComponent<EnemyBullet>().SetDirection(direction);
        }

    }
}
