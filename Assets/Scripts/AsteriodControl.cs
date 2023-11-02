using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteriodControl : MonoBehaviour
{
    GameObject ScoreText;
    public GameObject Explosion;
    public GameObject Coins;
    float speed;

    void Start()
    {
        speed = 2f;
        ScoreText = GameObject.FindGameObjectWithTag("ScoreTextTag");
        Coins.SetActive(false);
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
    void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.tag == "PlayerShipTag") || (collision.tag == "PlayerBulletTag"))
        {
            PlayExplosion();
            ScoreText.GetComponent<GameScore>().Score += 10;
            Destroy(gameObject);
        }
    }
    void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(Explosion);
        explosion.transform.position = transform.position;
        CoinRewards();
    }

    void CoinRewards()
    {
        Coins.SetActive(true);
        GameObject coin = (GameObject)Instantiate(Coins);
        coin.transform.position = transform.position;
    }

}
