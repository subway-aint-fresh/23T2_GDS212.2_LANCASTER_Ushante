using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float timeLimit = 60f;       // time limit set in seconds
    private float currentTime;          // time remaining
    public TextMeshProUGUI timerText;   // reference to the tmp time text

    public GameObject gameOverWindow;   // reference to game over window


    // Start is called before the first frame update
    private void Start()
    {
        StartTimer();
    }

    // Update is called once per frame
    private void Update()
    {
        if (currentTime > 0f)
        {
            currentTime -= Time.deltaTime;
            UpdateTimerText();
        } 
        else
        {
            GameOver();
        }
    }

    //Timer

        public void StartTimer()
        {
            currentTime = timeLimit;
        }

        private void UpdateTimerText()
        {
            string minutes = Mathf.Floor(currentTime / timeLimit).ToString("00");
            string seconds = (currentTime % timeLimit).ToString("00");
            timerText.text = $"{minutes}:{seconds}";
        }

    //game finished method, throws up fail window
    private void GameOver()
    {
        currentTime = 0f;               //set time to 0
        Debug.Log("time out");

        gameOverWindow.SetActive(true); //lose window is set active
    }

    //Sends player to the homescreen/ homescene
    public void HomeScreen()
    {
        //Loads homescreen scene
        SceneManager.LoadScene(0);
    }

    //replays scene
    public void ReplayGame()
    {
        //reloads current game scene
        SceneManager.LoadScene(1);
    }
}
