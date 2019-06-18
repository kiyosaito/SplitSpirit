using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.Events;

/* Old Code
  //void OnTriggerEnter(myCollider:Collider)
  //{
  //    if(myCollider.name == "Exit")
  //    {
  //        SceneManagement.SceneManager.LoadScene("1");
  //    }
  //}
  // Update is called once per frame
  //void Update()
  //{
  //    GetComponent<BoxCollider2D>();
  //    SceneManager.LoadScene(sceneBuildIndex: 1,);
  //    Debug.Log("scene has been loaded");
  //}
  //public void LevelTwo()
  //{
  //    SceneManager.LoadScene(1);
  //}
  */

public class Exit : MonoBehaviour
{
    // Fires when Player enters the Trigger
    public UnityEvent onEnter, onExit;
   
    public void OnTriggerEnter2D(Collider2D col)
    {
        onEnter.Invoke();
    }
    public void OnTriggerExit2D(Collider2D col)
    {
        onExit.Invoke();
    }
  
    public void LoadNextScene()
    {
        // Get current scene
        Scene currentScene = SceneManager.GetActiveScene();
        // Plus curent scene by 1
        int nextScene = currentScene.buildIndex + 1;
        // Load that scene!
        SceneManager.LoadScene(nextScene);
        // Print which scene was loaded
        Debug.Log("Level " + nextScene.ToString() + " has been loaded");
    }
    public void LoadSpecificScene(int index)
    {
        SceneManager.LoadScene(index);
    }
}
