using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string currentScene;
    public GameObject winScreen;
    public GameObject loseScreen;

    void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;
        winScreen = GameObject.Find("WinScreen");
        loseScreen = GameObject.Find("LoseScreen");

        //winScreen.SetActive(false);
        //loseScreen.SetActive(false);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        Debug.Log("Player has quit the game");
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
