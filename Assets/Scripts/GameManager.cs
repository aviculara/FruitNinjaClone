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
    public float comboWait = 1f;
    public Text scoreText;
    public Text highscoreText;
    public Text comboText;
    [Header("Game Over Elements")]
    public GameObject gameOverPanel;
    [Header("Combo Elements")]
    public GameObject blade;
    private int comboCount = 0;
    

    private void getHighscore()
    {
        highscore = PlayerPrefs.GetInt("Highscore");
        highscoreText.text = "Best: " + highscore.ToString();
    }

    private void Start()
    {
        //PlayerPrefs.SetInt("Highscore", 15);
        getHighscore();
        comboText.enabled = false;
        //GameObject blade = GameObject.FindGameObjectWithTag("Blade");
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
        yield return new WaitForSeconds(comboWait);

        // Check the condition
        if (comboCount > 2)
        {
            // Condition was met within the specified time
            //Debug.Log("Combo! "+comboCount.ToString());
            comboText.text = comboCount.ToString() + " FRUIT COMBO! \n +" + comboCount.ToString();
            Vector3 bladePos = blade.transform.position;
            Vector3 screenPos = Camera.main.WorldToScreenPoint(bladePos);
            comboText.transform.position = screenPos;
            //Debug.Log(pos);
            comboText.enabled = true;
            IncreaseScore(comboCount);
            Invoke("DisableText", 3f);
            comboCount = 0;
            // Perform the action or call a method
        }
        else
        {
            // Condition was not met within the specified time
            //Debug.Log(".");
            comboCount = 0;
            // Handle the case where the condition is not met
        }
    }
    void DisableText()
    {
        // Disable the text after 3 seconds
        comboText.enabled = false;
    }
}
