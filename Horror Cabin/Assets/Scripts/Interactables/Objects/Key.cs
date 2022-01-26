namespace Interactables.Objects
{
    public class Key : Milestone
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
