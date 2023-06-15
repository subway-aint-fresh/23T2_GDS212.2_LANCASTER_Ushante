using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    public GameObject findImagePuzzle;    //reference to the find image popup

    private GameManager gameManager;


    private void Start()
    {
        gameManager = GameManager.Instance;
    }


    private void OnMouseDown()
    {
        // when the exit button is clicked, the find image prefab/ pop-up is set to inactive
        findImagePuzzle.SetActive(false);

        // this will then trigger the email send button to be interactable
        // eventually make it so it increases the pop-up's closed counter
        gameManager.ClosedPopup();

    }

}
