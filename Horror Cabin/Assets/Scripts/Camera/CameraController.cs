using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera mainCamera;
    [SerializeField] private Animator animator;
    
    void OnEnable() {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        mainCamera.Follow = GameObject.Find("Player").transform;
    }

    public void TriggerCutscene(string cutsceneName, bool active) {
        animator.SetBool(cutsceneName, active);
    }
}
