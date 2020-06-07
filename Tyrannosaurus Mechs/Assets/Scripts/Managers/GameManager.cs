using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    void Awake()
    {
        gameManager = this;
    }

    void Update()
    {
        AddExtraHealth();
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
