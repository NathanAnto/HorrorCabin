using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "SpeechList", menuName = "ScriptableObjects/SpeechList", order = 1)]
public class SpeechList : ScriptableObject {
    public string[] speeches;
}
