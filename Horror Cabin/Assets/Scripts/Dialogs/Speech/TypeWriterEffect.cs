using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using Interactables;
using UnityEngine;
using UnityEngine.UI;

public class TypeWriterEffect : MonoBehaviour
{
    [SerializeField] private float typewriterSpeed = 50f;
    [SerializeField] private Text textLabel;
    
    private ControlSpeechBehaviour speechUI;
    private string textBeingTyped;
    private bool startedTyping;

    private void Start() {
        speechUI = GameObject.Find("SpeechUI").GetComponent<ControlSpeechBehaviour>();
    }

    public void Run(string textToType) {
        print($"{textToType} == {textBeingTyped} " + textToType.Equals(textBeingTyped));
        if (!startedTyping && textBeingTyped != textToType) {
            Interrupt();
            StopCoroutine("TypeText");
            StartCoroutine(TypeText(textToType));
        }
    }

    private IEnumerator TypeText(string textToType) {
        startedTyping = true;
        textBeingTyped = textToType;
        speechUI.transform.GetChild(0).gameObject.SetActive(true);
        float t = 0;
        int charIndex = 0;

        while (charIndex < textToType.Length) {
            t += Time.deltaTime * typewriterSpeed;
            charIndex = Mathf.FloorToInt(t);
            charIndex = Mathf.Clamp(charIndex, 0, textToType.Length);

            textLabel.text = textToType.Substring(0, charIndex);
            
            yield return null;
        }
        textLabel.text = textToType;
        yield return new WaitForSeconds(3);

        Interrupt();
    }

    private void Interrupt()
    {
        print("INTERRUPTING TYPEWRITER");
        speechUI.transform.GetChild(0).gameObject.SetActive(false); 
        startedTyping = false;
        textBeingTyped = String.Empty;
    } 
}
