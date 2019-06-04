using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerM : MonoBehaviour
{

    public LevelManager levelScript;

    public int level=15;
    private void Awake()
    {
        levelScript = GetComponent<LevelManager>();
        InitGame();

    }

    void InitGame()
    {
        levelScript.SetupScene(level);
    }


}
