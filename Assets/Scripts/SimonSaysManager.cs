using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonSaysManager : MonoBehaviour
{
    private List<int> playerSequence = new List<int>();   // List to store the player's button presses
    private List<int> currentSequence = new List<int>();  // List to store the current sequence to follow

    public GameObject button1;              // Reference to the non-colored object button 1
    public GameObject button1Color;         // Reference to the colored child object of button 1

    public GameObject button2;              // Button 2 non-colored 
    public GameObject button2Color;         // Button 2 colored child

    public GameObject button3;              // Button 3 non-colored 
    public GameObject button3Color;         // Button 3 colored child

    public GameObject button4;              // Button 4 non-colored 
    public GameObject button4Color;         // Button 4 colored child

    private bool playerInputEnabled = false;  // Flag to control player input

    void Start()
    {
        // Set the initial state of the colored versions of the buttons
        button1Color.SetActive(false);
        button2Color.SetActive(false);
        button3Color.SetActive(false);
        button4Color.SetActive(false);

        StartCoroutine(PlaySequence());
    }

    IEnumerator PlaySequence()
    {
        // Generate a random sequence of button indices
        GenerateSequence(4);

        // Play the sequence automatically
        for (int i = 0; i < currentSequence.Count; i++)
        {
            yield return new WaitForSeconds(1f); // Delay between button activations
            PlayButton(currentSequence[i]);
        }

        // Enable player input after playing the sequence
        playerInputEnabled = true;
    }

    void Update()
    {
        // Handle player input only when player input is enabled
        if (playerInputEnabled)
        {
            // Handle player input based on button clicks or input detection mechanism
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                HandlePlayerInput(1);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                HandlePlayerInput(2);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                HandlePlayerInput(3);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                HandlePlayerInput(4);
            }
        }
    }

    public void HandlePlayerInput(int buttonIndex)
    {
        // Add the player's button press to the sequence
        playerSequence.Add(buttonIndex);

        // Compare player's sequence with expected sequence
        CheckPlayerSequence();
    }

    public void CheckPlayerSequence()
    {
        // Compare player's sequence with expected sequence
        if (playerSequence.Count == currentSequence.Count)
        {
            bool sequencesMatch = true;
            for (int i = 0; i < playerSequence.Count; i++)
            {
                if (playerSequence[i] != currentSequence[i])
                {
                    sequencesMatch = false;
                    break;
                }
            }

            if (sequencesMatch)
            {
                // Player's sequence matches the expected sequence
                CorrectSequence();
            }
            else
            {
                // Player's sequence does not match the expected sequence
                WrongSequence();
            }
        }
    }

    public void GenerateSequence(int length)
    {
        currentSequence.Clear(); // Clear the existing sequence

        // Generate a random sequence of button indices
        for (int i = 0; i < length; i++)
        {
            int randomIndex = Random.Range(1, 5); // Generate a random index between 1 and 4
            currentSequence.Add(randomIndex); // Add the index to the sequence list
        }
    }

    private void PlayButton(int buttonIndex)
    {
        switch (buttonIndex)
        {
            case 1:
                StartCoroutine(ActivateButton(button1Color, button1));
                break;
            case 2:
                StartCoroutine(ActivateButton(button2Color, button2));
                break;
            case 3:
                StartCoroutine(ActivateButton(button3Color, button3));
                break;
            case 4:
                StartCoroutine(ActivateButton(button4Color, button4));
                break;
        }
    }

    private IEnumerator ActivateButton(GameObject coloredButton, GameObject button)
    {
        coloredButton.SetActive(true);
        button.GetComponent<SpriteRenderer>().enabled = false;

        yield return new WaitForSeconds(0.5f); // Duration the colored button is active

        coloredButton.SetActive(false);
        button.GetComponent<SpriteRenderer>().enabled = true;
    }

    private void WrongSequence()
    {
        Debug.LogError("Wrong sequence. Try again.");

        // Disable player input while replaying the sequence
        playerInputEnabled = false;

        // Replay the sequence
        StartCoroutine(ReplaySequence());
    }

    private IEnumerator ReplaySequence()
    {
        // Replay the sequence for the player to observe
        for (int i = 0; i < currentSequence.Count; i++)
        {
            yield return new WaitForSeconds(1f); // Delay between button activations
            PlayButton(currentSequence[i]);
        }

        // Enable player input after replaying the sequence
        playerInputEnabled = true;
    }

    private void CorrectSequence()
    {
        Debug.Log("Correct sequence!");

        // Disable player input after a correct sequence
        playerInputEnabled = false;

        // Set popup to inactive
    }
}
