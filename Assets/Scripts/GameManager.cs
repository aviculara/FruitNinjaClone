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

    private int comboCount = 0;

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
        //Debug.Log("bomb");
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

    public void CheckForCombo()
    {
        if (comboCount == 0)
        {
            StartCoroutine(ComboTimer());
        }

        comboCount = comboCount + 1;
        
    }

    IEnumerator ComboTimer()
    {
        // Wait for a set amount of time (e.g., 5 seconds)
        yield return new WaitForSeconds(2f);

        // Check the condition
        if (comboCount > 2)
        {
            // Condition was met within the specified time
            Debug.Log("Combo! "+comboCount.ToString());
            comboCount = 0;
            // Perform the action or call a method
        }
        else
        {
            // Condition was not met within the specified time
            Debug.Log(".");
            comboCount = 0;
            // Handle the case where the condition is not met
        }
    }
}
