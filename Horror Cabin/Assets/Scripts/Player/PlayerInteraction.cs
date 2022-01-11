using Interactables;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public string currentMission { get; set; }
    public Interactable currentInteractable { get; set; }
    public bool isNearInteractable { get; set; }

    private void Update()
    {
        if (isNearInteractable && Input.GetKeyDown(KeyCode.E)) {
            currentInteractable.InteractWith();
        }
    }
}
