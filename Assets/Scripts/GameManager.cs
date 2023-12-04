using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Score Elements")]
    public int score;
    public int highscore;
    public Text scoreText;
    public Text highscoreText;
    [Header("Game Over Elements")]
    public GameObject gameOverPanel;

    private void getHighscore()
    {
        highscore = PlayerPrefs.GetInt("Highscore");
        highscoreText.text = "Best: " + highscore.ToString();
    }

    private void Start()
    {
        getHighscore();
    }
    public void IncreaseScore(int addedPoints)
    {
        score = score + addedPoints;
        scoreText.text = score.ToString();

        if(score> highscore)
        {
            PlayerPrefs.SetInt("Highscore", score);
            highscoreText.text = "Best: " + score.ToString();
        }
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
