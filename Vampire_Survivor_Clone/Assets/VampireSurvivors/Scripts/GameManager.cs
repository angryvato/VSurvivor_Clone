using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Player_Base player;    
    public GameObject gameOverScreen;
    public TextMeshProUGUI _timer;
    float _timeLeft = 1800f;

    private void Start()
    {
        player = FindObjectOfType<Player_Base>();        
    }

    private void Update()
    {
        CheckTime();

        if (player.Health <= 0)
        {
            EndGame();
        }
        if(player.Health > 0)
        {
            ResumeGame();
        }
    }
    void EndGame()
    {
        Time.timeScale = 0f;
        gameOverScreen.SetActive(true);
    }

    void PauseGame()
    {
        Time.timeScale = 0f;
    }

    void ResumeGame()
    {
        Time.timeScale = 1f;
        gameOverScreen.SetActive(false);
    }

    private void CheckTime()
    {
        if (_timeLeft > 0)
        {
            _timeLeft -= Time.deltaTime;
            UpdateTimer(_timeLeft);
        }
        if (_timeLeft <= 0)
        {
            EndGame();
        }
    }

    void UpdateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        _timer.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}
