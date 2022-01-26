using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ControlList", menuName = "ScriptableObjects/ControlList", order = 1)]
public class ControlList : ScriptableObject
{
    public Control[] controls;
}

[Serializable]
public class Control {
    public string key;
    public string description;

    public bool GetByKey(string key) {
        return this.key.ToLower() == key.ToLower();
    }
}
