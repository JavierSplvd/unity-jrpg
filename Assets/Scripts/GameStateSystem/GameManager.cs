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
    private static GameManager instance;
    public GameState CurrentState { get; private set; }
    public event Action<GameState> OnGameStateChange;

    // Getter for the singleton instance
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                // Look for an existing GameManager instance in the scene
                instance = FindObjectOfType<GameManager>();

                if (instance == null)
                {
                    // Create a new GameManager object if it doesn't exist
                    GameObject go = new GameObject("GameManager");
                    instance = go.AddComponent<GameManager>();
                }
            }

            return instance;
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
