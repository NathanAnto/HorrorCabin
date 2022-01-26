using System.Collections;
using UnityEngine;

namespace Interactables.Objects
{
    public class Fire : Milestone
    {
        public override void InteractWith()
        {
            if (isInteractable) {
                TriggerMilestoneEvent();
            } else {
                typewriterEffect.Run(playerInteraction.currentMission);
            }
        }
    }
}
