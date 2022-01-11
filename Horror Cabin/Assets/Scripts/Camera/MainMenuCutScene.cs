using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEditor;
using UnityEngine;

public class MainMenuCutScene : MonoBehaviour
{
    [SerializeField] private new CinemachineVirtualCamera camera;
    [SerializeField] private Transform cabinTransform;
    [SerializeField] private Transform playerTransform;

    // Start is called before the first frame update
    void Start() {
        camera.m_Lens.OrthographicSize = 25;
        camera.Follow = cabinTransform;
    }

    public void SwitchToPlayer() {
        camera.Follow = playerTransform;
        camera.m_Lens.OrthographicSize = 10;
    }
}
