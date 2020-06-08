using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public float timer;
    public Text textBox;
    public Text scoreText;

    public int score;
    public int scoreNeeded;
    public int lives;

    public GameObject Player;
    void Awake()
    {
        gameManager = this;
        textBox.text = timer.ToString();
        textBox.enabled = false;
        scoreText.text = score.ToString();
        scoreText.enabled = false;
        scoreNeeded = 500;
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

        scoreText.text = "Score: " + score.ToString();
        textBox.text = "Time: " + Mathf.Round(timer).ToString();
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
        scoreText.enabled = true;
        textBox.enabled = true;
        timer += 1 * Time.deltaTime;
    }

    public void LevelCompleted()
    {
        CheckHighScore();
    }

    public void GameOver()
    {
        if (lives <= 0)
        {
            Debug.Log("Game Over");
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


