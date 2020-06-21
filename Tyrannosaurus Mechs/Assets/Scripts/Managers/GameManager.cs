using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public float timer;
    public Text timerText;
    public Text scoreText;
    public Text hSText;

    public Text livesText;

    public int score;
    public int scoreNeeded;
    public int lives;

    public GameObject player;
    public GameObject gameWonScreen;
    public GameObject gameOverScreen;
    public PlayerMovement playerShipMovement;

    public float enableScreenTimer = 2;

    public bool gameStarted = false;
    void Awake()
    {
        gameManager = this;
        timerText.text = timer.ToString();
        timerText.enabled = false;
        scoreText.text = score.ToString();
        scoreText.enabled = false;
    }

    void Start()
    {
        if(playerShipMovement == null)
        {
            playerShipMovement = FindObjectOfType<PlayerMovement>();
        }
        if(gameWonScreen == null)
        {
            gameWonScreen = GameObject.FindGameObjectWithTag("WinScreen");
            gameWonScreen.SetActive(false);
        }
        if(gameOverScreen == null)
        {
            gameOverScreen = GameObject.FindGameObjectWithTag("LoseScreen");
            gameOverScreen.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            gameWonScreen.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            gameOverScreen.SetActive(true);
        }
        if (Input.GetKey(KeyCode.P))
        {
            score++;
        }

        if (score >= scoreNeeded)
        {
            AddExtraHealth();
        }

        if(gameStarted == true)
        {
            timer += 1 * Time.deltaTime;
        }

        livesText.text = lives.ToString();
        scoreText.text = "Score: " + score.ToString();
        timerText.text = "Time: " + Mathf.Round(timer).ToString();
        hSText.text = "HighScore: " + PlayerPrefs.GetInt("HighScore");
    }

    public void AddExtraHealth()
    {
        lives += 1;
        scoreNeeded = score * 2;
    }

    public void BeginGame()
    {
        //Start All Necessary Functions to happen when game Begins Here
        //This includes Timer, CameraMovement, etc...
        gameStarted = true;
        scoreText.enabled = true;
        timerText.enabled = true;
        hSText.enabled = true;
        BossFirePattern2.BFP2.Shoot();
    }

    public void LevelCompleted()
    {
        CheckHighScore();
    }

    public void GameWon()
    {
        gameWonScreen.SetActive(true);
    }

    public void GameOver()
    {
        if (lives <= 0)
        {
            playerShipMovement.GetComponent<PlayerHealth>().Death();
            Invoke("EnableScreen", enableScreenTimer);
        }
        else
        {
            lives--;
        }
    }

    public void CheckHighScore()
    {
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            PlayerPrefs.Save();
        }
    }

    public void EnableScreen()
    {
        gameOverScreen.SetActive(true);
    }
}


