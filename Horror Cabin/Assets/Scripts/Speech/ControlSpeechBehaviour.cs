using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControlSpeechBehaviour : MonoBehaviour
{
    [SerializeField] private Text description;
    [SerializeField] private PlayerInteraction playerInteraction;

    private ControlSpeech controlSpeech;

    private void Awake()
    {
        controlSpeech = ControlSpeech.GetInstance();
        controlSpeech.TextChanged += OnTextChanged;
        SceneManager.sceneLoaded += SceneLoaded;
    }

    private void SceneLoaded(Scene arg0, LoadSceneMode arg1) {
        playerInteraction = GameObject.Find("Player").GetComponent<PlayerInteraction>();
    }

    private void OnTextChanged() {
        print("Updating speech");
        description.text = playerInteraction.currentMission;
    }
}
