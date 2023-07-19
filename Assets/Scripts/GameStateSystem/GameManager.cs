using UnityEngine;
using System;

public enum GameState
{
    Map,
    Battle,
    Menu,
    Dialogue
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameState CurrentState { get; private set; }
    public event Action<GameState> OnGameStateChange;

    private void Awake()
    {
        // Ensure only one instance of GameManager exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetGameState(GameState newState)
    {
        CurrentState = newState;
        OnGameStateChange?.Invoke(newState);
    }

    public GameState GetGameState()
    {
        return CurrentState;
    }
}
