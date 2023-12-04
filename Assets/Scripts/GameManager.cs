using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Score Elements")]
    public int score;
    public Text scoreText;
    public Text highscoreText;
    [Header("Game Over Elements")]
    public GameObject gameOverPanel;

    public void IncreaseScore(int addedPoints)
    {
        score = score + addedPoints;
        scoreText.text = score.ToString();
    }

    public void onBombHit()
    {
        Debug.Log("bomb");
        //stop any movement in game
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //gameOverPanel.SetActive(false);
        Time.timeScale = 1;
    }
}
