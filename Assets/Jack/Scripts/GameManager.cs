using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{

    public BoardManager boardScript;

    private int level = 3;

    // Start is called before the first frame update
    void Awake()
    {
        boardScript = GetComponent<BoardManager>();
        InitGame();
    }

   
    void InitGame()
    {
        boardScript.SetupScene(level);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
