using System;
using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Interactables.Objects
{
    public class Door : Interactable
    {
        private IEnumerator coroutine;
        public override void InteractWith() {
            if (isInteractable) {
                // Change scene to appropriate room
                switch (name) {
                    case "Open Window": {
                        GetComponent<SpeechUpdater>().UpdateIndex();
                        SceneManager.LoadScene("CabinScene");
                        break;
                    }
                    case "Exit Window": {
                        SceneManager.LoadScene("ForestScene");
                        break;
                    }
                }
            } else {
                typewriterEffect.Run(playerInteraction.currentMission);
            }
        }
    }
}
