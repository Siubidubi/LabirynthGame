using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager { get; private set; }
    public int timeToEnd = 240;
    private bool gamePaused = false;

    private bool endGame = false;
    private bool Win = false;

    private void Awake()
    {
        if(gameManager == null)
        {
            gameManager = this;
        }
    }

    public void EndGame()
    {
        CancelInvoke("Stopper");
        if (Win == true)
            Debug.Log("You won! Reload?");
        else Debug.Log("You lost. Reload?");
    }

    public void PauseGame()
    {
        Debug.Log("Game Paused");
        gamePaused = true;
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        Debug.Log("Game Resumed");
        gamePaused = false;
        Time.timeScale = 1.0f;
    }

    public void Stopper()
    {
        if(timeToEnd <= 0)
        {
            timeToEnd = 120;
        }
        timeToEnd--;
        Debug.Log("Time: " + timeToEnd + "s");

        if(timeToEnd <= 0)
        {
            timeToEnd = 0;
            endGame = true;
        }
            
        if(endGame == true)
        {
            EndGame();
        }
    }


    void Start()
    {
        InvokeRepeating("Stopper", 1, 1);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            if (gamePaused == true)
                ResumeGame();
            else PauseGame();
        }
    }
}
