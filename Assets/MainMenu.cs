using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MainMenu : MonoBehaviour
{
    public GameObject PauseMenu;
    private bool Paused;
    private Controls controls;

    void Awake()
    {
        controls = new Controls();
    }

    void Start()
    {
        Paused = false;
        controls.Gameplay.Pause.performed += PausePressed;
    }

    void PausePressed(InputAction.CallbackContext context)
    {
        print(PauseMenu);
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

    void ResumePressed()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        Paused = !Paused;
    }
}
