using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public BoardManager boardScript;


    private int level = 3;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
            Destroy(gameObject);
        boardScript = GetComponent<BoardManager>();
        InitGame();
    }

   
    void InitGame()
    {
        boardScript.SetupScene(level);
    }
    
    public void GameOver()
    {
        enabled = false;
    }
    void Update()
    {
        
    }
}
