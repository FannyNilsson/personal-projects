using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscore : MonoBehaviour
{
    public GameObject player;
    public static float powerUpPoints;
    public static float highestYPos;
    public static float currentTotalScore;
    public static float highScore1;
    public static float highScore2;
    public static float highScore3;
    public bool gameOver;
    public bool stopUpdate;

    public Text highScoreValueText;
    public Text currentScoreValueText;

	// Use this for initialization
	void Start ()
    {
        //Reset();
        stopUpdate = false;
        highestYPos = 0;
        currentTotalScore = 0;
        highScore1 = PlayerPrefs.GetFloat("HighScore1");
        highScore2 = PlayerPrefs.GetFloat("HighScore2");
        highScore3 = PlayerPrefs.GetFloat("HighScore3");

        highScoreValueText.text = highScore1.ToString();
        currentScoreValueText.text = currentTotalScore.ToString();
    }

    // Update is called once per frame
    void Update ()
    {
        gameOver = GameOver.gameOver;
        if(highestYPos <= Mathf.Round(player.transform.position.y))
        {
            highestYPos = player.transform.position.y;
        }
        if(gameOver == true && currentTotalScore > highScore3 && stopUpdate == false)
        {
            if(currentTotalScore > highScore2 && currentTotalScore <= highScore1)
            {
                highScore3 = highScore2;
                highScore2 = currentTotalScore;
                PlayerPrefs.SetFloat("HighScore3", highScore3);
                PlayerPrefs.SetFloat("HighScore2", highScore2);
            }
            if(currentTotalScore > highScore1)
            {
                highScore3 = highScore2;
                PlayerPrefs.SetFloat("HighScore3", highScore3);
                highScore2 = highScore1;
                PlayerPrefs.SetFloat("HighScore2", highScore2);
                highScore1 = currentTotalScore;
                PlayerPrefs.SetFloat("HighScore1", highScore1);
            }
            else
            {
                highScore3 = currentTotalScore;
                PlayerPrefs.SetFloat("HighScore3", highScore3);
            }
            stopUpdate = true;
        }
        currentTotalScore = highestYPos + powerUpPoints;
        highScoreValueText.text = highScore1.ToString();
        currentScoreValueText.text = currentTotalScore.ToString();
    }

    private void Reset()
    {
        highScore1 = 0;
        highScore2 = 0;
        highScore3 = 0;
        PlayerPrefs.SetFloat("HighScore1", 0);
        PlayerPrefs.SetFloat("HighScore2", 0);
        PlayerPrefs.SetFloat("HighScore3", 0);
    }
}
