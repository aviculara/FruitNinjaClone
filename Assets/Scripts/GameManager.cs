using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score;
    public Text scoreText;
    public Text highscoreText;

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
    }

}
