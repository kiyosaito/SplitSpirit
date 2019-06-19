using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false; // The game is not paused
    public GameObject pauseMenuUI;
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetKeyDown(KeyCode.Escape)) // If Escape key is pressed the game will pause
        {
            if (GameIsPaused)
            {
                Resume(); // Is the game is paused this will resume game
            }
            else
            {
                Pause(); // This will pause the game
            }
        }

	}
   public void Resume()
    {
        pauseMenuUI.SetActive(false); // Game is playing
        Time.timeScale = 1f; // Time is running at normal rate
        GameIsPaused = false; // Game is not paused
    }

   void Pause()
    {
        pauseMenuUI.SetActive(true); // Pauses the game
        Time.timeScale = 0f; // Time stop when paused
        GameIsPaused = true; // The game is paused
    }
    public void LoadMenu()
    {
        Debug.Log("Loading Menu...");
        SceneManager.LoadScene("Menu"); // Loads the menu
        Time.timeScale = 1f; // Time runs at normal rate
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game..."); // Console message
        Application.Quit(); // Quits the game
    }




}
