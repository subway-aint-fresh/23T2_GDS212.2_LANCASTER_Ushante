using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float timeLimit = 60f;       // Time limit set in seconds
    private float currentTime;          // Time remaining
    public TextMeshProUGUI timerText;   // Reference to the TMP time text

    public GameObject gameOverWindow;   // Reference to the game over window
    public GameObject gameWinWindow;    // Reference to the game win window

    private void Start()
    {
        StartTimer();
    }

    private void Update()
    {
        if (currentTime > 0f)
        {
            currentTime -= Time.deltaTime;
            UpdateTimerText();
        }
        else
        {
            GameFailed();
        }
    }

    // Timer
        public void StartTimer()
        {
            currentTime = timeLimit;
            UpdateTimerText();
        }

        private void UpdateTimerText()
        {
            int minutes = Mathf.FloorToInt(currentTime / 60f);
            int seconds = Mathf.FloorToInt(currentTime % 60f);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

            // Make sure the timer text updates properly through a check
            if (minutes <= 0 && seconds <= 0)
            {
                timerText.text = "00:00";
            }
            else
            {
                timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            }
    }

    // Ends the game and throws up a game over window 
    private void GameFailed()
    {
        currentTime = 0f;
        gameOverWindow.SetActive(true);
    }

    //Ends the game and throws up a game win window
    public void GameWin()
    {
        currentTime = 0f;
        gameWinWindow.SetActive(true);
    }

    // Loads home screen scene
    public void HomeScreen()
    {
        SceneManager.LoadScene("HomeScreen");
    }

    // Replays the game
    public void ReplayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
