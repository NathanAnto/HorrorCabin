using System.Collections.Generic;
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

        protected Dictionary<string, string> scenes = new Dictionary<string, string>();

        private void Start() {
            playerInteraction = GameObject.FindWithTag("Player").GetComponent<PlayerInteraction>();
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

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.tag.Equals("Player")) {
                Debug.Log("Player in " + name);
                playerInteraction.currentInteractable = this;
                playerInteraction.isNearInteractable = true;
            }
        }

        private void OnTriggerExit2D(Collider2D other) {
            if (other.tag.Equals("Player")) {
                playerInteraction.currentInteractable = null;
                playerInteraction.isNearInteractable = false;
            }
        }
    }
}
