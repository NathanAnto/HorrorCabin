using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class SpeechUpdater : MonoBehaviour
{
    private PlayerInteraction playerInteraction;
    private ControlSpeech controlSpeech;
    
    private void Awake() {
        playerInteraction = GameObject.Find("Player").GetComponent<PlayerInteraction>();
        controlSpeech = ControlSpeech.GetInstance();
    }

    public void UpdateIndex() {
        // print("Updating speech from " + Speeches.missionIndex + " to " + (Speeches.missionIndex + 1));
        Speeches.UpdateIndex();
        playerInteraction.currentMission = playerInteraction.SpeechListMain.speeches[Speeches.missionIndex];
        controlSpeech.ChangeText();
        Destroy(this);
    }
}
