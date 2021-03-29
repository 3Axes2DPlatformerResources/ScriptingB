using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour {
    [SerializeField] private GameObject dialogueBoxGameObject;
    [SerializeField] private TextMeshProUGUI textComponent;
    [SerializeField] private Dialogue dialogue;
    [SerializeField] private TextMeshProUGUI buttonTextComponent;

    private int currentLineIndex;
    
    void Start() {
        currentLineIndex = 0;
        textComponent.text = dialogue.DialogueLines[currentLineIndex];
    }
    
    public void DisplayNextDialogueLine() {
        currentLineIndex++;
        if (currentLineIndex < dialogue.DialogueLines.Count) {
            textComponent.text = dialogue.DialogueLines[currentLineIndex];
            if (currentLineIndex == dialogue.DialogueLines.Count - 1)
                buttonTextComponent.text = "Fermer";
        }
        else
            dialogueBoxGameObject.SetActive(false);
    }
}
