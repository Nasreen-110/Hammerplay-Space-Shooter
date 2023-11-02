using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Powerup : MonoBehaviour
{
    public bool activateShield;
    public bool addGuns;
    public bool increaseSpeed;
    public GameObject powerups;
    float speed;
  
    void Start()
    {
        speed = 3f;
    }

    void Update()
    {
        Vector2 position = transform.position;
        position = new Vector2(position.x, position.y - speed * Time.deltaTime);
        transform.position = position;
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        if (transform.position.y < min.y)
        {
            Destroy(gameObject);
        }
    }

}