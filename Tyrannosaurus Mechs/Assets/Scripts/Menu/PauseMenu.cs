using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool gameIsPaused = false;

    public GameObject pauseMenuUI = null;
    public GameObject _Options;
    //public GameObject thePlayer = null;

    public AudioSource audSrc;
    public AudioClip _On;

    public GameObject charselect;
    public GameObject pilotselect;
    public GameObject _confirmation;
    public GameObject _win;
    public GameObject _loose;

    private string currScene;

    void Start()
    {
        pauseMenuUI = GameObject.Find("PausePanel");
        _Options = GameObject.Find("Options Menu");
        audSrc = GetComponent<AudioSource>();
        pauseMenuUI.SetActive(false);
        _Options.SetActive(false);
        currScene = SceneManager.GetActiveScene().name;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        if(charselect.activeInHierarchy == true || 
           pilotselect.activeInHierarchy == true || 
           _confirmation.activeInHierarchy == true || 
           _win.activeInHierarchy == true || 
           _loose.activeInHierarchy == true ||
           pauseMenuUI.activeInHierarchy == true)
        {
            Cursor.visible = true;
        }
        else
        {
            Cursor.visible = false;
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        gameIsPaused = false;
        Cursor.visible = false;
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Cursor.visible = true;
        Time.timeScale = 0f;
        audSrc.PlayOneShot(_On);
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
}
