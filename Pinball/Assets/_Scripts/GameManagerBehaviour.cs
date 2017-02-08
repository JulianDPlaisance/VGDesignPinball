using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerBehaviour : MonoBehaviour
{
    public enum STATES {MAINMENU, GAMEPLAY, CREDITS};
    public STATES state; 
    public Text scoreText, creditScoreText, livesText;
    public static int score;
    public int lives;
    private int scoreLives;
    public GameObject pinballObject;
    public GameObject pinballs;

    public GameObject mainMenu, gameplayMenu, creditsMenu;

    public bool noPinball = true;
    // Use this for initialization
	void Start ()
    {
        state = STATES.MAINMENU;

        mainMenu.SetActive(true);
        gameplayMenu.SetActive(false);
        creditsMenu.SetActive(false);

        score = 0;
        scoreLives = 5000;
        lives = 3;

        pinballs = pinballObject.gameObject;
        pinballs.GetComponent<PinballBehvaiour>().SetManager(this.gameObject);

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case STATES.MAINMENU:
                break;

            case STATES.GAMEPLAY:
                scoreText.text = "Score: " + score;
                livesText.text = "Lives: " + lives;
                if (noPinball == true && lives > 0)
                {
                    Instantiate(pinballs, new Vector3(-7, 10, 0), new Quaternion(0, 0, 0, 0));
                    noPinball = false;
                }
                if (lives <= 0)
                {
                    LostGame();
                }

                if (score >= scoreLives)
                {
                    lives++;
                    scoreLives *= 2;
                }
                break;

            case STATES.CREDITS:
                creditScoreText.text = "Score: " + score;
                break;
        }
	}

    public void IncScore(int amt)
    {
        score += amt;
    }
    public void LostBall()
    {
        lives--;
        noPinball = true;
    }

    public void MainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");

        DestroyImmediate(gameObject);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("pinball");

        mainMenu.SetActive(false);
        gameplayMenu.SetActive(true);
        creditsMenu.SetActive(false);

        score = 0;

        state = STATES.GAMEPLAY;

        
    }

    public void LostGame()
    {
        state = STATES.CREDITS;

        UnityEngine.SceneManagement.SceneManager.LoadScene("Credits");
        lives = 3;

        mainMenu.SetActive(false);
        gameplayMenu.SetActive(false);
        creditsMenu.SetActive(true);
    }

}
