using System;
using System.Collections;
using System.Collections.Generic;
using Interactables;
using UnityEngine;

public class Note : Interactable
{
    [SerializeField] private Animator animator;
    
    public override void InteractWith()
    {
        if (isInteractable) {
            // Show next note
            animator.SetTrigger("OpenNote");
            isInteractable = false;
            GameStateManager.Instance.SetState(GameState.Paused);
        } else {
            base.InteractWith();
        }
    }

    private void FixedUpdate()
    {
        if (!isInteractable && Input.GetKeyDown(KeyCode.E))
        {
            GameStateManager.Instance.SetState(GameState.Gameplay);
            animator.SetTrigger("CloseNote");
            // Destroy(gameObject);
        }
    }
}
