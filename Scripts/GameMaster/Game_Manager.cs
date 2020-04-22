using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    private bool gameEnded = false;

    public GameObject gameOverUI;
    public GameObject winnerUI;

    public string nextLevel = "Level02";
    public int levelToUnlock = 2;

    public SceneFader sceneFader;

    // Update is called once per frame
    void Update()
    {
        if (gameEnded)
            return;

        if (Input.GetKeyDown("space"))
        {
            EndGame(gameOverUI, false);
        }

        if(PlayerStats.Lives <= 0)
        {
            EndGame(gameOverUI, false);
        }

        if(PlayerStats.Lives > 0 && PlayerStats.killEnemy + PlayerStats.destroyEnemy == PlayerStats.Enemy)
        {
            EndGame(winnerUI, true);
        }
    }

    void EndGame(GameObject obj, bool win)
    {
        gameEnded = true;
        obj.SetActive(true);
        if(win == true)
        {
            PlayerPrefs.SetInt("levelReached", levelToUnlock);
            //sceneFader.FadeTo(nextLevel);
        }
    }
}

