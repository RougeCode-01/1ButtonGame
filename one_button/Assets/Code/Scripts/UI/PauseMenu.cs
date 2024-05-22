using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool gamePaused = false;
    public GameObject pauseMenu;
    public string firstScene = "RotatingMechanism";
    public GameObject bgm;
    public bool soundPlaying = true;
    public GameObject soundOn;
    public GameObject muted;

    private void Awake()
    {
        gamePaused = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePaused)
            {
                Resume();
            }
            else
                Pause();
        }
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        gamePaused = false;
    }
    public void Pause()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        gamePaused = true;
    }
    public void Restart()
    {
        SceneManager.LoadScene(firstScene);
    }
    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Sound()
    {
        if (soundPlaying == true)
        {
            bgm.SetActive(false);
            muted.SetActive(true);
            soundOn.SetActive(false);
            soundPlaying = false;
        }
        else 
        {
            soundPlaying = true;
            bgm.SetActive(true);
            muted.SetActive(false);
            soundOn.SetActive(true);
        }
    }
}
