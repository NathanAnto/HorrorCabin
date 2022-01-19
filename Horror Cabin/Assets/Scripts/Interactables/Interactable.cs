using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Interactables
{
    [System.Serializable]
    public class Interactable : MonoBehaviour
    {
        [SerializeField] public new string name;
        [SerializeField] public bool isInteractable;

        protected PlayerInteraction playerInteraction;

        private ControlDialogBehaviour dialogUI;
        protected ControlSpeechBehaviour speechUI;
        protected TypeWriterEffect typewriterEffect;

        private void Awake()
        {
            dialogUI = GameObject.Find("DialogUI").GetComponent<ControlDialogBehaviour>();
            speechUI = GameObject.Find("SpeechUI").GetComponent<ControlSpeechBehaviour>();
            typewriterEffect = GameObject.Find("TypewriterEffect").GetComponent<TypeWriterEffect>();
            playerInteraction = GameObject.FindWithTag("Player").GetComponent<PlayerInteraction>();
            
            dialogUI.transform.GetChild(0).gameObject.SetActive(false);
            speechUI.transform.GetChild(0).gameObject.SetActive(false);
        }

        public virtual void InteractWith() {
            if(isInteractable)
                Debug.Log("Interacted with " + name);
            else
                Debug.Log("Can't interact with " + name);
        }
    
        public void ChangeState() {
            isInteractable = !isInteractable;
        }
        
        private void OnTriggerEnter2D(Collider2D other) {
            if (other.tag.Equals("Player")) {
                playerInteraction.NearInteractable();
            }
        }

        private void OnTriggerStay2D(Collider2D other) {
            if (other.tag.Equals("Player")) {
                dialogUI.transform.GetChild(0).gameObject.SetActive(true);
                playerInteraction.currentInteractable = this;
                playerInteraction.isNearInteractable = true;
            }
        }

        private void OnTriggerExit2D(Collider2D other) {
            if (other.tag.Equals("Player")) {
                dialogUI.transform.GetChild(0).gameObject.SetActive(false);
                playerInteraction.currentInteractable = null;
                playerInteraction.isNearInteractable = false;
            }
        }
    }
}
