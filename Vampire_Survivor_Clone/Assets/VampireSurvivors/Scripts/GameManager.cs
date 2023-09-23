using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Player_Base player;    
    public GameObject gameOverScreen;

    private void Start()
    {
        player = FindObjectOfType<Player_Base>();        
    }

    private void Update()
    {
        if (player.Health <= 0)
        {
            PauseGame();
        }
        if(player.Health > 0)
        {
            ResumeGame();
        }
    }
    void PauseGame()
    {
        Time.timeScale = 0f;
        gameOverScreen.SetActive(true);
    }

    void ResumeGame()
    {
        Time.timeScale = 1f;
        gameOverScreen.SetActive(false);
    }    
}
