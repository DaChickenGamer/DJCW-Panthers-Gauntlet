using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState state;

    public static event Action<GameState> OnGameStateChanged;

    void Awake()
    {
        Instance = this;
    }

    private void Start() 
    {
        UpdateGameState(GameState.Tutorial);
    }
    
    public void UpdateGameState(GameState newState)
    {
        state = newState;

        switch(newState)
        {
            case GameState.Tutorial:
                break;
                HandleTutorial();
            case GameState.InRing:
                break;
                HandleInRing();
            case GameState.PlayerLose:
                break;
                HandlePlayerLose();
            case GameState.PlayerWin:
                break;
                HandlePlayerWin();
            default:
            throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        OnGameStateChanged?.Invoke(newState);
    }

    private void HandleTutorial()
    {

    }

    private void HandleInRing()
    {
        
    }

    private void HandlePlayerLose()
    {
        
    }

    private void HandlePlayerWin()
    {
        
    }

    public enum GameState
    {
        Tutorial,
        InRing,
        PlayerLose,
        PlayerWin
    }
}
