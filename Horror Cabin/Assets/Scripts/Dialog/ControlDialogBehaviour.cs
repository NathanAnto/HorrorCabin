using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ControlDialogBehaviour : MonoBehaviour
{
    [SerializeField] private Transform controlDialogCanvas;
    [SerializeField] private ControlList controlList;
    private Text key;
    private Text description;

    private ControlDialog controlDialog;

    private void Start()
    {
        controlDialog = ControlDialog.GetInstance();
        controlDialog.TextChanged += OnTextChanged;
        
        key = controlDialogCanvas.GetChild(0).GetChild(0).GetComponent<Text>();
        description = controlDialogCanvas.GetChild(1).GetComponent<Text>();
    }

    private void OnTextChanged(object sender, TextChangedArgs e)
    {
        var c = new Control();
        foreach (var control in controlList.controls) {
            if (control.GetByKey(e.key)) c = control;
        }

        if (c.key != null) {
            key.text = c.key;
            description.text = c.description;
        } else {
            key.text = "!";
            description.text = "KEY NOT FOUND";
        }
    }
}
