using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //if timer runs out, execute homescreen method

    //Sends player to the homescreen/ homescene
    public void HomeScreen()
    {
        //Loads homescreen scene
        SceneManager.LoadScene(0);
    }
}
