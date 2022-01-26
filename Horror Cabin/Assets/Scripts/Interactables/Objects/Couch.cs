using System.Collections;
using System.Collections.Generic;
using Interactables;
using UnityEngine;

public class Couch : Interactable
{
    public override void InteractWith()
    {
        if (isInteractable) {
            // SIT DOWN ON COUCH
            print("SITTING ON COUCH");
        } else {
            base.InteractWith();
        }
    }
}
