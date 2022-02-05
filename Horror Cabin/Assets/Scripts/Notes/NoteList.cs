using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NotesList", menuName = "ScriptableObjects/NotesList", order = 1)]
public class NoteList : ScriptableObject {
    public string[] notes;
}
