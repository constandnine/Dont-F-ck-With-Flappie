using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public float gameTimer;
    public string timerFormatted;
    public static float  highScore;
    public static int points;

    public TextMeshProUGUI timer, pointUi, timeUpPoints;
    public GameObject timeUpScreen;

    public bool timerOn;
    public static bool gameOver;
    private void Start()
    {
        points = 0;
        timerOn = true;
    }

    private void Update()
    {
        timer.text = gameTimer.ToString("F2");
        if (timerOn)
        {
            gameTimer -= Time.deltaTime;
            DisplayTime(gameTimer);
            pointUi.text = points.ToString();
            if (gameTimer < 0)
            {
            
                timerOn = false;
                gameOver = true;

                timeUpScreen.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                timeUpPoints.text = ("Your score:" + points);
                //time over screen with points
                //do things
            }
        }

    }
    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float milliSeconds = (timeToDisplay % 1) * 1000;

        timer.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliSeconds);
    }


    public void AddPoints()
    {
       // points =+ pointsEarned;
        pointUi.text = points.ToString();
        if (points > highScore)
        {
            SetHighscore();
        }
    }

    public void SetHighscore()
    {
        //set new highscore whoooo
        highScore = points;
        PlayerPrefs.SetFloat("highScore", highScore);
    }
}
