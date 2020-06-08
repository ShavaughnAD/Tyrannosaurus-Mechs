using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public float timer;
    public Text textBox;
    public Text scoreText;
    public int score;

    void Awake()
    {
        gameManager = this;
        textBox.text = timer.ToString();
        textBox.enabled = false;
        scoreText.text = score.ToString();
        scoreText.enabled = false;
    }

    void Update()
    {
        AddExtraHealth();
        scoreText.text = "Score: " + score.ToString();
        textBox.text = "Time: " + Mathf.Round(timer).ToString();
    }

    public void AddExtraHealth()
    {
        //After Score Has Reached A Certain Value, this function will do whats necessary
        //Have the if checks here, but the function will continually be called in Update
        //Performance currently isn't a concern so calling this is Update continually should be fine
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
        //Bring up Game Over Screen Here

    }

    public void CheckHighScore()
    {

    }
}
