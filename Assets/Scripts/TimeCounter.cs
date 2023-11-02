using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeCounter : MonoBehaviour
{
    TextMeshProUGUI timeText;
    float startTime;
    float elapsedTime;
    bool startCounter;
    int minutes;
    int seconds;

    void Start()
    {
        startCounter = false;
        timeText = GetComponent<TextMeshProUGUI>();
    }

    public void StartTimeCounter()
    {
        startTime = Time.time;
        startCounter = true;
    }

    public void EndTimeCounter()
    {
        startCounter = false;
    }

    void Update()
    {
        if (startCounter)
        {
            elapsedTime = Time.time - startTime;
            minutes = (int) elapsedTime / 60;
            seconds = (int) elapsedTime % 60;
            timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}
