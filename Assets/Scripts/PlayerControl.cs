using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;
using Input = UnityEngine.Input;

public class PlayerControl : MonoBehaviour
{
    public GameObject Gamemanager;
    public GameObject PlayerBullets;
    public GameObject Bullet1;
    public GameObject Bullet2;
    public GameObject PowerUpBullets;
    public GameObject Bullet3;
    public GameObject Explosion;
    public AudioSource audioSource1;
    public AudioSource audioSource2;
    public AudioSource audioSource3;
    // shield
    GameObject shield;    
    public float duration = 10f; 
    public bool isActive = false;
    public float StartTime;
    //weapon
    bool hasGun;
    GameObject powerBullet;
    //speed
    public float speed;
    bool hasSpeed;

    public TextMeshProUGUI LivesUIText;
    const int MaxLives = 3;
    int lives;

    //Mobile
    //float accelStartY;
    bool RegularBullets;

    public void Init()
    {
        lives = MaxLives;
        LivesUIText.text = lives.ToString();
        transform.position = new Vector2 (0, 0);
        gameObject.SetActive(true);
    }

    void Awake()
    {
        hasGun = false;
        hasSpeed = false;
    }

    void Start()
    {
        //accelStartY = Input.acceleration.y;
        shield = transform.Find("Shield").gameObject;//shield
        shield.SetActive(false);
        powerBullet = transform.Find("Gun").gameObject;
        powerBullet.SetActive(false);
    }

    void Update()
    {
        
        //bullet
        //if (Input.GetKeyDown("space")) //stystem
        if (RegularBullets)
        {
            if (hasGun)
            {
                if (Time.time - StartTime < duration)
                {
                    AddBullet();
                }
                else
                {
                    hasGun = false;
                }
            }
            else
            {
                FireRegularBullets();
            }
        }
        else if (!RegularBullets)
        {
            FireRegularBullets();
        }

        ///System movements
        //float x = Input.GetAxisRaw("Horizontal");
        //float y = Input.GetAxisRaw("Vertical");
        //Vector2 direction = new Vector2(x, y).normalized;

        ///mobile movements
        float x = Input.acceleration.x;
        float y = Input.acceleration.y; //- accelStartY

        Vector2 direction = new Vector2(x,y);
        if (direction.sqrMagnitude > 1)
            direction.Normalize();

        Move(direction);

        // shield
        if (isActive)
        {
            if (Time.time - StartTime >= duration)
            {
                DeactivateShield();
            }
        }

        //speed
        if (hasSpeed == false)
        {
            speed = 4f;
        }
        else if (hasSpeed ==true && Time.time - StartTime >= duration)
        {
            hasSpeed = false;
            UpgradePlayerSpeed(); 
        }

    }

    public void ShootBtn()
    {
        if (!RegularBullets)
        {
            PlayAudio1();
            GameObject bullet1 = Instantiate(PlayerBullets);
            bullet1.transform.position = Bullet1.transform.position;
            GameObject bullet2 = Instantiate(PlayerBullets);
            bullet2.transform.position = Bullet2.transform.position;
        }
        else if (RegularBullets)
        {
            PlayAudio1();
            GameObject bullet1 = Instantiate(PlayerBullets);
            bullet1.transform.position = Bullet1.transform.position;
            GameObject bullet2 = Instantiate(PlayerBullets);
            bullet2.transform.position = Bullet2.transform.position;
            GameObject bullet3 = Instantiate(PowerUpBullets);
            bullet3.transform.position = Bullet3.transform.position;
        }
    }

    void FireRegularBullets()
    {
        if (RegularBullets == true)
        {
            ShootBtn();
        }
        //PlayAudio1();
        //GameObject bullet1 = Instantiate(PlayerBullets);
        //bullet1.transform.position = Bullet1.transform.position;
        //GameObject bullet2 = Instantiate(PlayerBullets);
        //bullet2.transform.position = Bullet2.transform.position;
    }
    //Weapon
    void AddBullet()
    {
        if (RegularBullets == false)
        {
            ShootBtn();
        }
        //PlayAudio1();
        //GameObject bullet1 = Instantiate(PlayerBullets);
        //bullet1.transform.position = Bullet1.transform.position;
        //GameObject bullet2 = Instantiate(PlayerBullets);
        //bullet2.transform.position = Bullet2.transform.position;
        //GameObject bullet3 = Instantiate(PowerUpBullets);
        //bullet3.transform.position = Bullet3.transform.position;

    }

    void Move(Vector2 direction)
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2 (0,0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));
        max.x = max.x - 0.4f;
        min.x = min.x + 0.4f;
        max.y = max.y - 0.6f;
        min.y = min.y + 0.6f;
        Vector2 pos = transform.position;
        pos += direction * speed * Time.deltaTime;
        pos.x = Mathf.Clamp (pos.x, min.x, max.x);
        pos.y = Mathf.Clamp (pos.y, min.y, max.y);
        transform.position = pos;
    }

    // shield
    void ActivateShield()
    {
        
        if (!isActive)
        {           
            isActive = true;
            StartTime = Time.time;
            shield.SetActive(true);
           
        }
    }

    // shield
    void DeactivateShield()
    {
       
        if (isActive)
        {

            isActive = false;
            shield.SetActive(false);
        }
    }

    // shield
    bool HasShield()
    {
        {
            return shield.activeSelf;
        }
    }
    // Upgrade
    void UpgradePlayerSpeed()
    {
        speed += 10f;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.tag == "EnemyShipTag") || (collision.tag == "EnemyBulletTag"))
        {
            PlayExplosion();
            if (isActive)
            {
                if (HasShield())
                {
                    DeactivateShield();
                }
            }
            else
            {
                lives--;
                LivesUIText.text = lives.ToString();
                if (lives == 0)
                {
                    Gamemanager.GetComponent<GameManager>().SetGameManagerState(GameManager.GameManagerState.GameOver);
                    gameObject.SetActive(false);
                }
            }
        }

        if ((collision.tag == "CoinTag"))
        {
            PlayAudio2();
        }

        if ((collision.tag == "ShieldTag"))
        {
            PlayAudio3();
        }

        // shield
        Powerup powerUp = collision.GetComponent<Powerup>();
        if (powerUp)
        {
            if (powerUp.activateShield)
            {
                ActivateShield();

            }
            else if (powerUp.addGuns)
            {
                hasGun = true;
                StartTime = Time.time;
            }
            else if (powerUp.increaseSpeed)
            {
                hasSpeed = true;
                StartTime = Time.time;
                UpgradePlayerSpeed();
            }

            Destroy(powerUp.gameObject);
        }

    }
    void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(Explosion);
        explosion.transform.position = transform.position;
    }

    void PlayAudio1()
    {
        audioSource1.Play();
    }

    void PlayAudio2()
    {
        audioSource2.Play();
    }

    void PlayAudio3()
    {
        audioSource3.Play();
    }
}
