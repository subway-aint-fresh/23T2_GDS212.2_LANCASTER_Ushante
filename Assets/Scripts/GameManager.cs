using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public float timeLimit = 60f;       // Time limit set in seconds
    private float currentTime;          // Time remaining
    public TextMeshProUGUI timerText;   // Reference to the TMP time text

    public GameObject gameOverWindow;   // Reference to the game over window
    public GameObject gameWinWindow;    // Reference to the game win window

    private int correctSelections;
    private int wrongSelections;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

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

    // Find Image Puzzle

    // Method responsible for checking if the image selections are correct
    public void CheckImageSelections()
    {
        Debug.Log("CheckImageSelections method called");
        ImageSelection[] imageSelections = FindObjectsOfType<ImageSelection>();

        correctSelections = 0;
        wrongSelections = 0;

        foreach (ImageSelection imageSelection in imageSelections)
        {
            if (imageSelection.IsSelected)
            {
                if (imageSelection.gameObject.layer == LayerMask.NameToLayer("CorrectImage"))
                {
                    correctSelections++;
                }
                else if (imageSelection.gameObject.layer == LayerMask.NameToLayer("WrongImage"))
                {
                    wrongSelections++;
                }
            }
        }

        Debug.Log("Correct Selections: " + correctSelections);
        Debug.Log("Wrong Selections: " + wrongSelections);

        if (correctSelections >= 6 && wrongSelections <= 3)
        {
            // Trigger a method in the GameManager to handle the successful selection of 6 correct images.
            SuccessfulImageSelection();
        }
    }


    private void SuccessfulImageSelection()
    {
        // Set exit button to active
        Debug.Log("pop up done");
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
