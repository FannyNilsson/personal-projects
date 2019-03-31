using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public static bool gameOver;
    public GameObject player;
    public Canvas gameOverCanvas;
    public Button replayLevel;
    public Button backToMain;

    private float currentLowestPossiblePos;

	// Use this for initialization
	void Start ()
    {
        backToMain = backToMain.GetComponent<Button>();
        replayLevel = replayLevel.GetComponent<Button>();

        gameOverCanvas.enabled = false;
        backToMain.enabled = false;
        replayLevel.enabled = false;
        gameOver = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (currentLowestPossiblePos < player.transform.localPosition.y-10)
        {
            currentLowestPossiblePos = player.transform.localPosition.y-10;
        }
        if (player.transform.localPosition.y < currentLowestPossiblePos && gameOver == false)
        {
            GLHF();
        }
        if(gameOver)
        {
            GLHF();
        }
    }

    public void GLHF()
    {
        backToMain = backToMain.GetComponent<Button>();
        replayLevel = replayLevel.GetComponent<Button>();
        gameOver = true;
        gameOverCanvas.enabled = true;
        backToMain.enabled = true;
        replayLevel.enabled = true;
        //disable controls of player
    }

    public void BackToMainPress()
    {
        Application.LoadLevel(0);
    }

    public void ReplayLevel()
    {
        //Inte hårdkoda levelnumret
        Application.LoadLevel(Application.loadedLevel);
    }
}
