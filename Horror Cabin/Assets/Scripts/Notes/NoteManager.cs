using System.Collections;
using System.Collections.Generic;
using UnityEditor.Localization.Plugins.XLIFF.V12;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public static int noteIndex { get; private set; }
    
    public static void UpdateIndex() {
        print($"index {noteIndex} going to {noteIndex+1}");
        noteIndex++;
    }
}
