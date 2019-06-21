using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene(1); // Load the first scene
    }

    public void QuitGame()
    {
        Debug.Log("Quit"); // Message to appear in the console during play mode
        Application.Quit(); // closes the game
    }


}
        







