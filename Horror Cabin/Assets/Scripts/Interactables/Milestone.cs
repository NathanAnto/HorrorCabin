using System;

namespace Interactables
{
    [System.Serializable]
    public class Milestone : Interactable
    {
        public Interactable[] affectedInteractables;

        /// <summary>
        /// Trigger Milestone event that changes the state of other interactables
        /// </summary>
        public void TriggerMilestoneEvent() {
            foreach (var interactable in affectedInteractables) {
                interactable.ChangeState();
            }

            affectedInteractables = Array.Empty<Interactable>();
        }
    }
}
