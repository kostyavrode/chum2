using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum GameState
{
    OFF = 0,
    PLAYING = 1,
    PAUSED = 2,
    FINISHED = 3
}
public class GameManager : MonoBehaviour
{
    public static Action<GameState> onGameStateChange;
    private GameState state;
    public void ChangeGameState(GameState state)
    {
        switch (state)
        {
            case GameState.OFF:
                break;
            case GameState.PLAYING:
                break;
            case GameState.PAUSED:
                break;
            case GameState.FINISHED:
                break;
        }
        onGameStateChange?.Invoke(state);
    }
}

