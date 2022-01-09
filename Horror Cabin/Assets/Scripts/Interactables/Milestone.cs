using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Milestone : Interactable
{
    public Interactable[] affectedInteractables;

    /// <summary>
    /// Trigger Milestone event that changes the state of other interactables
    /// </summary>
    public void TriggerEvent()
    {
        foreach (var interactable in affectedInteractables) {
            interactable.ChangeState();
        }
    }
}
