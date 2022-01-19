using System.Collections;
using UnityEngine;

namespace Interactables.Objects
{
    public class Fire : Interactable
    {
        private IEnumerator coroutine;
        
        public override void InteractWith()
        {
            if (isInteractable) {
                // Start Fire animation
            } else {
                typewriterEffect.Run(playerInteraction.currentMission);
            }
        }
    }
}
