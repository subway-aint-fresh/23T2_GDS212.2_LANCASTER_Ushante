using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float timeLimit = 60f; // time limit set in seconds
    private float currentTime; // time remaining
    private TextMeshProUGUI timerText; // reference to the tmp time text


    // Start is called before the first frame update
    private void Start()
    {
        timerText = GetComponent<TextMeshProUGUI>();
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
            currentTime = 0f;
            Debug.Log("time out");
            //execute game finished
        }
    }

    //Timer

        public void StartTimer()
        {
            currentTime = timeLimit;
        }

        private void UpdateTimerText()
        {
            string minutes = Mathf.Floor(currentTime / 60f).ToString("00");
            string seconds = (currentTime % 60f).ToString("00");
            timerText.text = $"{minutes}:{seconds}";
        }

    //game finished method, throws up fail window

    //Sends player to the homescreen/ homescene
    public void HomeScreen()
    {
        //Loads homescreen scene
        SceneManager.LoadScene(0);
    }
}
