using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirePlaceCutScene : MonoBehaviour
{    
    [SerializeField] private CameraController cameraAnimationController;
    private bool cutsceneState = false;
    
    private void Start() {
        cameraAnimationController = GameObject.Find("StateCamera").GetComponent<CameraController>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag.Equals("Player")) {
            StartCoroutine(TriggerCutscene());
            GetComponent<SpeechUpdater>()?.UpdateIndex();
        }
    }

    private IEnumerator TriggerCutscene() {
        cutsceneState = !cutsceneState;
        cameraAnimationController.TriggerCutscene("FirePlaceCutScene", cutsceneState);
        yield return new WaitForSeconds(3);
        cameraAnimationController.TriggerCutscene("FirePlaceCutScene", false);
        Destroy(gameObject);
    }
}
