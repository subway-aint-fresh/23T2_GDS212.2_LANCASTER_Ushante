using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonSaysManager : MonoBehaviour
{
    public GameObject button1;              // Reference to the non-colored object button 1
    public GameObject button1Color;         // Reference to the colored child object of button 1

    public GameObject button2;              // Button 2 non-colored 
    public GameObject button2Color;         // Button 2 colored child

    public GameObject button3;              // Button 3 non-colored 
    public GameObject button3Color;         // Button 3 colored child

    public GameObject button4;              // Button 4 non-colored 
    public GameObject button4Color;         // Button 4 colored child

    void Start()
    {
        // Set the initial state of the colored versions of the buttons
        button1Color.SetActive(false);
        button2Color.SetActive(false);
        button3Color.SetActive(false);
        button4Color.SetActive(false);
    }

    void Update()
    {
        
    }

    public void HandlePlayerInput(int buttonIndex)
    {
        switch (buttonIndex)
        {
            case 1:
                button1.GetComponent<SpriteRenderer>().enabled = false;
                button1Color.SetActive(true);
                break;
            case 2:
                button2.GetComponent<SpriteRenderer>().enabled = false;
                button2Color.SetActive(true);
                break;
            case 3:
                button3.GetComponent<SpriteRenderer>().enabled = false;
                button3Color.SetActive(true);
                break;
            case 4:
                button4.GetComponent<SpriteRenderer>().enabled = false;
                button4Color.SetActive(true);
                break;
        }
    }

}
