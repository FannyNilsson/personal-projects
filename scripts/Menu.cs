using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public Button startB;
    public Button highScoreB;
    public Button exitB;
    public Button howToPlayB;

    public Canvas quitMenu;
    public Button noQuitButton;
    public Button yesQuitButton;

    public Canvas levelSelectMenu;
    public Button lvl1B;
    public Button backtoMainMenuB;

    public Canvas howToPlayMenu;
    public Button backtoMainFromHowTo;

    public Canvas characterSelectCanvas;
    public Button backFromCharacterSelect;
    public Button jonathanSelected;
    public Button ninnieSelected;
    public GameObject jonathan;
    public GameObject ninnie;

    public Canvas highscoreCanvas;
    public Button backtoMainFromHighScore;
    public Text placement1Text;
    public Text placement2Text;
    public Text placement3Text;
    private float highScore1;
    private float highScore2;
    private float highScore3;

    public static int levelNumber;


    void Start ()
    {
        startB = startB.GetComponent<Button>();
        highScoreB = highScoreB.GetComponent<Button>();
        exitB = exitB.GetComponent<Button>();
        howToPlayB = howToPlayB.GetComponent<Button>();
        lvl1B = lvl1B.GetComponent<Button>();
        backtoMainMenuB = backtoMainMenuB.GetComponent<Button>();
        backtoMainFromHowTo = backtoMainFromHowTo.GetComponent<Button>();

        ninnie.SetActive(false);
        jonathan.SetActive(false);

        howToPlayMenu.enabled = false;
        levelSelectMenu.enabled = false;
        lvl1B.enabled = false;
        backtoMainMenuB.enabled = false;
        characterSelectCanvas.enabled = false;

        highScore1 = PlayerPrefs.GetFloat("HighScore1");
        highScore2 = PlayerPrefs.GetFloat("HighScore2");
        highScore3 = PlayerPrefs.GetFloat("HighScore3");

        levelNumber = 0;
    }

    public void startPress()
    {
        levelSelectMenu.enabled = true;
        lvl1B.enabled = true;
        backtoMainMenuB.enabled = true;

        startB.enabled = false;
        highScoreB.enabled = false;
        exitB.enabled = false;
        howToPlayB.enabled = false;
    }

    public void lvl1Press()
    {
        levelNumber = 1;
        CharacterSelect();
    }

    public void lvl2Press()
    {
        levelNumber = 2;
        CharacterSelect();
    }

    public void backtoMainMenuPress()
    {
        levelSelectMenu.enabled = false;
        lvl1B.enabled = false;
        backtoMainMenuB.enabled = false;

        startB.enabled = true;
        highScoreB.enabled = true;
        exitB.enabled = true;
        howToPlayB.enabled = true;
    }

    public void exitPress()
    {
        quitMenu.enabled = true;
        yesQuitButton.enabled = true;
        noQuitButton.enabled = true;

        startB.enabled = false;
        highScoreB.enabled = false;
        exitB.enabled = false;
        howToPlayB.enabled = false;
    }

    public void YesQuitPress()
    {
        Application.Quit();
    }

    public void NoQuitPress()
    {
        quitMenu.enabled = false;
        yesQuitButton.enabled = false;
        noQuitButton.enabled = false;

        startB.enabled = true;
        highScoreB.enabled = true;
        exitB.enabled = true;
        howToPlayB.enabled = true;
    }

    public void highScorePress()
    {
        highscoreCanvas.enabled = true;
        backtoMainFromHighScore.enabled = true;

        startB.enabled = false;
        highScoreB.enabled = false;
        exitB.enabled = false;
        howToPlayB.enabled = false;

        placement1Text.text = highScore1.ToString();
        placement2Text.text = highScore2.ToString();
        placement3Text.text = highScore3.ToString();

    }

    public void howToPress()
    {
        howToPlayMenu.enabled = true;
        backtoMainFromHowTo.enabled = true;

        startB.enabled = false;
        highScoreB.enabled = false;
        exitB.enabled = false;
        howToPlayB.enabled = false;
    }

    public void backFromHowToPlay()
    {
        howToPlayMenu.enabled = false;
        backtoMainFromHowTo.enabled = false;

        startB.enabled = true;
        highScoreB.enabled = true;
        exitB.enabled = true;
        howToPlayB.enabled = true;
    }

    public void backtoMainMenuPressHS()
    {
        highscoreCanvas.enabled = false;
        backtoMainFromHighScore.enabled = false;

        startB.enabled = true;
        highScoreB.enabled = true;
        exitB.enabled = true;
        howToPlayB.enabled = true;
    }

    public void backFromCharacter()
    {
        characterSelectCanvas.enabled = false;
        jonathanSelected.enabled = false;
        ninnieSelected.enabled = false;
        backFromCharacterSelect.enabled = false;
        ninnie.SetActive(false);
        jonathan.SetActive(false);

        levelSelectMenu.enabled = true;
        lvl1B.enabled = true;
        //backtoMainMenuB.enabled = true;
    }

    public void CharacterSelect()
    {
        characterSelectCanvas.enabled = true;
        jonathanSelected.enabled = true;
        ninnieSelected.enabled = true;
        backFromCharacterSelect.enabled = true;
        ninnie.SetActive(true);
        jonathan.SetActive(true);

        levelSelectMenu.enabled = false;
        lvl1B.enabled = false;
        //backtoMainMenuB.enabled = false;
    }

    public void selectNinnie()
    {
        //SÄTT CHARACTER-BOOL SOM SPARAS VID SCENBYTE
        if(levelNumber == 1)
        {
            Application.LoadLevel(3);
        }
        else if(levelNumber == 2)
        {
            Application.LoadLevel(5);
        }
        
    }

    public void selectJonathan()
    {
        Debug.Log(levelNumber);
        //SÄTT CHARACTER-BOOL SOM SPARAS VID SCENBYTE
        if (levelNumber == 1)
        {
            Application.LoadLevel(2);
        }
        else if (levelNumber == 2)
        {
            Application.LoadLevel(4);
        }
    }
}
