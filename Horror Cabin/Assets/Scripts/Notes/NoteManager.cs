using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public static int noteIndex { get; private set; }
    
    public static void UpdateIndex() {
        noteIndex++;
    }
}
