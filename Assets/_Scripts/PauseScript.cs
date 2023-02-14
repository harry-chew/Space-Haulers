using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameController;

public class PauseScript : MonoBehaviour
{
    [SerializeField] private bool isPaused;

    private void OnEnable()
    {
        GameController.OnStateChange += HandleStateChange;
    }

    private void OnDisable()
    {
        GameController.OnStateChange -= HandleStateChange;
    }

    private void HandleStateChange(GameState state)
    {
        if (state != GameState.Paused) return;

        TogglePause();
    }

    private void Start()
    {
        isPaused = false;
    }

    private void Update()
    {
        HandlePause();
    }

    private void HandlePause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    private void TogglePause()
    {
        if (isPaused)
            UnPause();
        else
            Pause();
    }

    private void Pause()
    {
        Time.timeScale = 0.0f;
        isPaused = true;
        
    }

    private void UnPause()
    {
        Time.timeScale = 1.0f;
        isPaused = false;
    }
}
