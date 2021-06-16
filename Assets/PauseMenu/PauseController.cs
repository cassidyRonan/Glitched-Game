using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseController : MonoBehaviour {

    public GameObject pauseScreen;
    public GameObject pauseButtons;
    public GameObject settingsScreen;

    public void Pause()
    {
        pauseScreen.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void UnPause()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void ExitSettings()
    {
        settingsScreen.SetActive(false);
        pauseButtons.SetActive(true);
    }

    public void Settings()
    {
        settingsScreen.SetActive(true);
        pauseButtons.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Pause();
        }
    }
}
