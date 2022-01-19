namespace Interactables.Objects
{
    public class Key : Milestone
    {
        public override void InteractWith()
        {
            if (isInteractable) {
                TriggerMilestoneEvent();
                // Destroy(gameObject);
            } else {
                typewriterEffect.Run(playerInteraction.currentMission);
            }
            
        }
    }
}
