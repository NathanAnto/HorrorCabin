using System;
using Interactables;
using System.Linq;
using UnityEngine;

namespace Player
{
    public class PlayerInteraction : MonoBehaviour
    {
        public SpeechList SpeechListMain;
        public string currentMission { get; set; }
        public Interactable currentInteractable { get; set; }
        public bool isNearInteractable { get; set; }

        private ControlDialog controlDialog;
        private ControlSpeech controlSpeech;
        private GameObject OptionsCanvas;

        private void Awake() {
            currentMission = SpeechListMain.speeches[Speeches.missionIndex];
            controlDialog = ControlDialog.GetInstance();
            controlSpeech = ControlSpeech.GetInstance();
        }

        private void Start() {
            OptionsCanvas = Resources.FindObjectsOfTypeAll<GameObject>().ToList()
                .Find(obj => obj.name == "OptionsCanvas");
            controlSpeech.ChangeText();
        }

        private void Update() {
            // Interact with objects
            if (isNearInteractable && Input.GetKeyDown(KeyCode.E)) {
                currentInteractable.InteractWith();
            }
            // Toggle flashlight
            if (Input.GetKeyDown(KeyCode.F)) {
                // TODO - Create flashlight
            }
            // Toggle pause
            if (Input.GetKeyDown(KeyCode.Escape) && GetComponent<PlayerMovement>().enabled) {
                OptionsCanvas.SetActive(!OptionsCanvas.activeSelf);
            }
        }

        public void NearInteractable() {
            // If is and interactable
            controlDialog.ChangeText("E");
        }
    }
}
