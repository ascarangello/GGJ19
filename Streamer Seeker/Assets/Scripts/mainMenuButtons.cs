using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mainMenuButtons : MonoBehaviour
{
    public Button startButton, quitButton;
    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(startGame);
        quitButton.onClick.AddListener(quitGame);
    }

    //should move to twitch info screen
    void startGame()
    {
        
    }
    //simply quits game
    void quitGame()
    {
        Application.Quit();
        Debug.Log("Quit!");
    }
}
