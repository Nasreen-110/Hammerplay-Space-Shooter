using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CoinCollider : MonoBehaviour
{
    GameObject ScoreText;
    float speed;

    void Awake()
    {
        Invoke("CollectCoins", 1f);
        ScoreText = GameObject.FindGameObjectWithTag("ScoreTextTag");
    }

    void Start()
    {
        speed = 3.5f;
        
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

    void CollectCoins()
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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerShipTag")
        {
            ScoreText.GetComponent<GameScore>().Score += 10;
            Destroy(gameObject);
        }
    }
}
