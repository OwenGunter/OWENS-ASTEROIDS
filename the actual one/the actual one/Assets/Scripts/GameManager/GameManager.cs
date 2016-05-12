using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    // will automatically load all the data from the high scores file when it is created during the Start function
   
    // a public tanks array used to check each object in the array and determine whether the tank is alive or not
    public GameObject[] m_Ships;
    // References to the code below
    public Text m_MessageText;

 
   


    // The names of the game states
    public enum GameState
    {
        Start,
        Playing,
        GameOver
    };

    //referencing the above game states
    private GameState m_GameState;
    public GameState State { get { return m_GameState; } }



    private void Awake()
    {
        m_GameState = GameState.Start;
    }

    // Use this for initialization
    private void Start()
    {
        // disabling the tanks so that the enemy doesnt shoot before the game begins
        for (int i = 0; i < m_Ships.Length; i++)
        {
            m_Ships[i].SetActive(false);
        }

        // displays the start message
        m_MessageText.text = "Press Enter When Ready";

        // setting variables to false
     
       // m_NewGameButton.gameObject.SetActive(false);
      
    }

    // Update is called once per frame
    void Update()
    {
        switch (m_GameState)
        {
            // waitng for the player to press the return key to start the game or otherwise known as the(Enter Key)
            case GameState.Start:
                if (Input.GetKeyUp(KeyCode.Return) == true)
                {
                    // when the game starts, start the timer
                  
                    m_MessageText.text = "";
                    // switch to the playing Gamestate
                    m_GameState = GameState.Playing;
                    for (int i = 0; i < m_Ships.Length; i++)
                    {
                        m_Ships[i].SetActive(true);
                    }
                }
                break;
            case GameState.Playing:

                bool isGameOver = false;

             
             
                // checking if there is one tank left
                if (OneShipLeft() == true)
                {
                    isGameOver = true;
                }
                // checking if player tank is dead
                else if (IsPlayerDead() == true)
                {
                    isGameOver = true;
                }

                if (isGameOver == true)
                {
                    // switch to the gameover Gamestate
                    m_GameState = GameState.GameOver;
                  
                    // when in game over state enable the buttons
                  //  m_NewGameButton.gameObject.SetActive(true);
                  //  m_HighScoresButton.gameObject.SetActive(true);
                    // when the player dies display the message press enter to continue
                    if (IsPlayerDead() == true)
                    {
                        m_MessageText.text = "Stay Determined";
                    }
                    else
                   
                    {
                        m_MessageText.text = "WINNER! Press Enter to Continue";
                     
                    }

                    

                }
                break;
            case GameState.GameOver:
                // when the game is over pressing the enter key will switch to the start gamestate
                if (Input.GetKeyUp(KeyCode.Return) == true)
                {
                  
                    m_GameState = GameState.Playing;
                    m_MessageText.text = "";
                   
                    // setting the tanks alive!
                    for (int i = 0; i < m_Ships.Length; i++)
                    {
                        m_Ships[i].SetActive(true);
                    }
                }
                break;
        }
        // when the escape button is pressed quit the application
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    // checks how many tanks there are in the scene
    private bool OneShipLeft()
    {

        int numTanksLeft = 0;
        for (int i = 0; i < m_Ships.Length; i++)
        {
            // if player is alive the update function will stop the game
            if (m_Ships[i].activeSelf == true)
            {
                numTanksLeft++;
            }
        }
        return numTanksLeft <= 1;
    }
    // checks if the player tank is destroyed 
    private bool IsPlayerDead()
    {
        //  This check by the Update function will end the game as soon as the player dies – even if there are multiple enemy tanks remaining.
        for (int i = 0; i < m_Ships.Length; i++)
        {
            if (m_Ships[i].activeSelf == false)
            {
                if (m_Ships[i].tag == "Player")
                    return true;
            }
        }
        return false;
    }

    

   

    // on the new game set the variables to false except for the timer text and tanks
    public void OnNewGame()
    {
        /*m_NewGameButton.gameObject.SetActive(false);
        m_HighScoresButton.gameObject.SetActive(false);
        m_HighScorePanel.SetActive(false);*/
     
        m_GameState = GameState.Playing;
        m_MessageText.text = "";
        for (int i = 0; i < m_Ships.Length; i++)
        {
            m_Ships[i].SetActive(true);
        }
    }

    



}