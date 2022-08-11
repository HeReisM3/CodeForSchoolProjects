using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject settingsMenu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Resume()
    {
        settingsMenu.SetActive(false);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    private void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void Settings()
    {
        pauseMenuUI.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void LoadMenu()
    {
        Debug.Log("Loading menu..");
    }

    public void QuitToMenu()
    {
        PauseMenuScript.gameIsPaused = false;
        SceneManager.LoadScene("MainMenu");
    }
}
