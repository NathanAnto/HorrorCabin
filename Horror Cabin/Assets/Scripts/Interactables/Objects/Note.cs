using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Interactables.Objects
{
    public class Note : Interactable
    {
        [SerializeField] private NoteList noteList;
        
        private Animator animator;
        private Text textUI;
        private event Action OnNoteOpen;

        public override void InteractWith()
        {
            var noteUI = GameObject.Find("NoteUI").transform.GetChild(0);
            animator = noteUI.GetComponent<Animator>();
            textUI = noteUI.transform.GetChild(0).GetComponent<Text>();
            Debug.Log("Note", noteUI);
        
            if (isInteractable) {
                // Show next note
                animator.SetTrigger("OpenNote");
                isInteractable = false;
                textUI.text = noteList.notes[NoteManager.noteIndex];
                NoteManager.UpdateIndex();
                GameStateManager.Instance.SetState(GameState.Paused);
                StartCoroutine(WaitAfterNoteOpen());
            } else {
                base.InteractWith();
            }
        }

        /// <summary>
        /// Wait 3 seconds before being able to close note
        /// </summary>
        private IEnumerator WaitAfterNoteOpen()
        {
            yield return new WaitForSeconds(3);
            // After 3 seconds let player close note
            OnNoteOpen += CloseNote;
        }

        private void Update() {
            if (Input.anyKey) {
                OnNoteOpen?.Invoke();
                OnNoteOpen -= CloseNote;
            }
        }
    
        /// <summary>
        /// Close note if not interactable
        /// </summary>
        public void CloseNote()
        {
            if (!isInteractable)
            {
                print("closing note");
                GameStateManager.Instance.SetState(GameState.Gameplay);
                animator.SetTrigger("CloseNote");
                StopAllCoroutines();
                Destroy(gameObject);
            }
        }
    }
}
