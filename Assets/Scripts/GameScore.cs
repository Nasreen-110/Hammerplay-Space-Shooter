using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameScore : MonoBehaviour
{
    TextMeshProUGUI scoreText;
    int score;

    int targetScoreForLevel2 = 800; 
    int targetScoreForLevel3 = 1200;
    int reset = 1800;

    public int Score
    {
        get
        {
            return this.score;
        }
        set
        {
            this.score = value;
            UpdateScoreText();

            if (score >= targetScoreForLevel2 && (SceneManager.GetActiveScene().name == "Level1"))
            {
                Debug.Log("Loading if condition for Level 2");
                LoadLevel2();
            }

            if (score >= targetScoreForLevel3 && (SceneManager.GetActiveScene().name == "Level2"))
            {
                Debug.Log("Loading if condition for Level 3");
                LoadLevel3();
            }

            if (score >= reset && (SceneManager.GetActiveScene().name == "Level3"))
            {
                Debug.Log("Loading if condition for Level 3");
                Menu();
            }
        }
    }

    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    void UpdateScoreText()
    {
        string scoreStr = string.Format("{0:0000000}", score);
        scoreText.text = scoreStr;
    }

    void LoadLevel2()
    {
        Debug.Log("Loading Level 2");
        SceneManager.LoadScene(2);
    }

    void LoadLevel3()
    {
        Debug.Log("Loading Level 3");
        SceneManager.LoadScene(3);
    }
    void Menu()
    {
        Debug.Log("Loading Main Menu");
        SceneManager.LoadScene(0);
    }
}
