using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    //Checks if the Game is paused
    public static bool GameIsPaused = false;

    public GameObject PauseMenuUI;

    private void Update()
    {
        //Checks for the Escape input
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            }else
            {
                Pause();
            }
        }
    }

    //Resumes the game
    public void Resume()
    {
        //Make the pause menu inactive
        PauseMenuUI.SetActive(false);
        //Resume the time of the game
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    private void Pause()
    {
        //Makes the pause menu active
        PauseMenuUI.SetActive(true);
        //Set the time scale to 0 so the game pauses
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        //Resumes the game, becuase if I just go to the menu and play again the game is still frozen
        Time.timeScale = 1f;
        //Loads the main menu
        SceneManager.LoadScene(0);
    }
    
}
