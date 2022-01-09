using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public class Interactable : MonoBehaviour
{
    [SerializeField] public new string name;
    [SerializeField] public bool isInteractable;

    private PlayerInteraction playerInteraction;

    private void Start() {
        playerInteraction = GameObject.FindWithTag("Player").GetComponent<PlayerInteraction>();
    }

    public void InteractWith() {
        Debug.Log("Interacted with " + name);
    }
    
    public void ChangeState() {
        isInteractable = !isInteractable;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag.Equals("Player")) {
            playerInteraction.currentInteractable = this;
            
            if (Input.GetKeyDown(KeyCode.E)) InteractWith();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag.Equals("Player")) playerInteraction.currentInteractable = null;
    }
}
