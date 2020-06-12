using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool gameIsPaused = false;

    public GameObject pauseMenuUI = null;
    //public GameObject thePlayer = null;

    public AudioSource audSrc;
    public AudioClip _On;

    public GameObject charSelect;

    private string currScene;

    void Start()
    {
        pauseMenuUI = GameObject.Find("PausePanel");
        //thePlayer = GameObject.Find("Gup");
        audSrc = GetComponent<AudioSource>();
        pauseMenuUI.SetActive(false);
        charSelect = GameObject.Find("MainCanvas");
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

        //if (charSelect.activeInHierarchy == false)
        //{
        //    Cursor.visible = false;
        //}
        //else if (charSelect.activeInHierarchy == true)
        //{
        //    Cursor.visible = true;
        //}

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
