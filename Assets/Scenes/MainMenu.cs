using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject MainMenuScreen;
    private bool Paused;

    void Start()
    {
        Paused = true;
    }

    void OnPause()
    {
        if (Paused)
        {
            Time.timeScale = 1f;
            Paused = !Paused;
            PauseMenu.SetActive(false);
        }
        else if (!Paused)
        {
            Time.timeScale = 0f;
            PauseMenu.SetActive(true);
            Paused = !Paused;
        }
        else
        {
            Debug.Log("Pause function not working, check MainMenu.cs");
        }
    }

    public void ResumePressed()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        Paused = !Paused;
    }

    public void ExitGamePressed()
    {
        Application.Quit();
    }

    public void NewGamePressed()
    {
        Time.timeScale = 1f;
        Paused = !Paused;
        MainMenuScreen.SetActive(false);

    }

    public void RestartGamePressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
