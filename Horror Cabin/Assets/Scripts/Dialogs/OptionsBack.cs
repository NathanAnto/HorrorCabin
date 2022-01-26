using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsBack : MonoBehaviour
{
    public bool startedPlaying;

    private GameObject mainMenuCanvas;

    private void Awake() {
        mainMenuCanvas = GameObject.Find("MainMenuCanvas");
    }

    public void PlayGame() => startedPlaying = true;

    public void Back() {
        Debug.Log("PLAYING ? " + startedPlaying);
        if (!startedPlaying) {
            mainMenuCanvas.SetActive(true);
        }
    }
}
