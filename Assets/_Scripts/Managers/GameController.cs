using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private bool isPaused;
    [SerializeField] private GameState gameState;
    public GameState previousGameState;
    public static event Action<GameState> OnStateChange;
    public static GameController Instance { get; private set; }
    public GameController GetInstance()
    {
        return Instance;
    }

    public enum GameState
    {
        MainMenu,
        Paused,
        Building,
        Playing,
        GameOver
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    void Start()
    {
        InitialiseGame();
    }

    void Update()
    {
        HandlePause();
    }

    private void OnGUI()
    {
        if (GUILayout.Button("Change State"))
        {
            SetGameState(gameState);
        }
    }


    public void SetGameState(GameState state)
    {
        previousGameState = gameState;
        gameState = state;

        if (state != GameState.Paused) isPaused = false;
        
        switch (state)
        {
            case GameState.MainMenu:
                OnStateChange?.Invoke(GameState.MainMenu);
                break;
            case GameState.Paused:
                OnStateChange?.Invoke(GameState.Paused);
                break;
            case GameState.Building:
                OnStateChange?.Invoke(GameState.Building);
                break;
            case GameState.Playing:
                OnStateChange?.Invoke(GameState.Playing);
                break;
            case GameState.GameOver:
                OnStateChange?.Invoke(GameState.GameOver);
                break;
            default:
                break;
        }
    }

    public GameState GetGameState()
    {
        return gameState;
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
        SetGameState(GameState.Paused);
    }

    private void UnPause()
    {
        Time.timeScale = 1.0f;
        isPaused = false;
        gameState = previousGameState;
        SetGameState(gameState);
    }

    private void InitialiseGame()
    {
        DontDestroyOnLoad(gameObject);
        SetGameState(GameState.Building);
    }
}
