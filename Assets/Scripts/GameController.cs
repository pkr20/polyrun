using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject gameOverPanel;
    public Text scoreText;
    int score = 0;
    void Start()
    {
        Time.timeScale = 1;
        gameOverPanel.SetActive(false);
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        
        gameOverPanel.SetActive(true);
    }

    public void IncrementScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
