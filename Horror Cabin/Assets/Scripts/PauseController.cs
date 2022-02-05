using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    [SerializeField] private GameObject optionsCanvas;
    private OptionsBack optionsBack;
    
    private void Start() {
        GameStateManager.Instance.SetState(GameState.Paused);
        optionsBack = GetComponent<OptionsBack>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && optionsBack.startedPlaying) {
            TriggerGameStateEscape();
        }
    }

    public void TriggerGameStateEscape()
    {
        TriggerGameState();
        var currentGameState = GameStateManager.Instance.CurrentGameState;
        optionsCanvas.SetActive(currentGameState == GameState.Paused);
    }

    public void TriggerGameState()
    {
        var currentGameState = GameStateManager.Instance.CurrentGameState;
        var newGameState = currentGameState == GameState.Gameplay
            ? GameState.Paused
            : GameState.Gameplay;
        
        GameStateManager.Instance.SetState(newGameState);
    }
}
