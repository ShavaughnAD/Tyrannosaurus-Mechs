using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public float timer;
    public Text timerText;
    public Text scoreText;

    public Text livesText;

    public int score;
    public int scoreNeeded;
    public int lives;

    public GameObject player;
    public PlayerMovement playerShipMovement;

    public bool gameStarted = false;

    void Awake()
    {
        gameManager = this;
        timerText.text = timer.ToString();
        timerText.enabled = false;
        scoreText.text = score.ToString();
        scoreText.enabled = false;
        scoreNeeded = 500;
    }

    void Start()
    {
        if(playerShipMovement == null)
        {
            playerShipMovement = FindObjectOfType<PlayerMovement>();
        }
    }

    void Update()
    {
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
        BossFirePattern2.BFP2.Shoot();
    }

    public void LevelCompleted()
    {
        CheckHighScore();
    }

    public void GameOver()
    {
        if (lives <= 0)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            lives--;
        }
        //Bring up Game Over Screen Here
    }

    public void CheckHighScore()
    {

    }
}


