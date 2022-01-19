using System.Collections;
using System.Collections.Generic;
using Interactables;
using UnityEngine;

public class FireItem : Interactable
{
    [SerializeField] private Interactable fireStart;
    private static int itemCount;
    
    public override void InteractWith() {
        itemCount++;
        print("Items " + itemCount);
        if (itemCount >= 3) {
            fireStart.ChangeState();
            GetComponent<SpeechUpdater>()?.UpdateIndex();
            typewriterEffect.Run($"Found {name}. That's all the items I need for the fire!");
        } else {
            typewriterEffect.Run("Found " + name);
        }
        Destroy(gameObject);
    }
}
