using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject playButton;
    public GameObject playerShip;
    public GameObject enemySpawner;
    public GameObject gameOver;
    public TextMeshProUGUI scoreText;
    public GameObject timeCounter;
    public GameObject gameTitle;
    public GameObject spriteToActivate;
    public GameObject powerUps;
    public GameObject shoot;

    public enum GameManagerState
    {
        Opening,
        Gameplay,
        GameOver,
    }

    GameManagerState state;
    int currentLevel = 1;
    void Start()
    {
        SetGameManagerState(GameManagerState.Opening);
    }

    void UpdateGameManagerState()
    {
        switch (state)
        {
            case GameManagerState.Opening:
                gameOver.SetActive(false);
                gameTitle.SetActive(false);
                playButton.SetActive(true);
                spriteToActivate.SetActive(false);
                powerUps.SetActive(false);
                break;

            case GameManagerState.Gameplay:
                scoreText.GetComponent<GameScore>().Score = 0;
                playButton.SetActive(false);
                powerUps.SetActive(true);
                playerShip.GetComponent<PlayerControl>().Init();
                enemySpawner.GetComponent<EnemySpawner>().StartLevel();
                timeCounter.GetComponent<TimeCounter>().StartTimeCounter();
                shoot.SetActive(true);
                spriteToActivate.SetActive(true);
                break;

            case GameManagerState.GameOver:
                gameTitle.SetActive(true);
                timeCounter.GetComponent<TimeCounter>().EndTimeCounter();
                gameOver.SetActive(true);
                shoot.SetActive(false);
                spriteToActivate.SetActive(false);
                enemySpawner.GetComponent<EnemySpawner>().StopEnemySpawner();
                Invoke("OpeningState", 5f);
                break;
        }
    }

    public void SetGameManagerState(GameManagerState newState)
    {
        state = newState;
        UpdateGameManagerState();
    }

    public void StartGame()
    {
        SetGameManagerState(GameManagerState.Gameplay);
    }

    public void OpeningState()
    {
        SetGameManagerState(GameManagerState.Opening);
    }

    public void AdvanceToNextLevel()
    {
        currentLevel++;
        if (currentLevel > 3)
        {
            SetGameManagerState(GameManagerState.GameOver);
        }
        else
        {
            SetGameManagerState(GameManagerState.Gameplay);
        }
    }
    void Update()
    {
        
    }
}
