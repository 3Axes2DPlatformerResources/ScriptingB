using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour {
    [SerializeField] private GameObject dialogueBoxGameObject;
    [SerializeField] private TextMeshProUGUI textComponent;
    [SerializeField] private Dialogue dialogue;

    private int currentLineIndex;
    
    void Start() {
        currentLineIndex = 0;
        textComponent.text = dialogue.DialogueLines[currentLineIndex];
    }
    
    public void DisplayNextDialogueLine() {
        currentLineIndex++;
        if (currentLineIndex < dialogue.DialogueLines.Count)
            textComponent.text = dialogue.DialogueLines[currentLineIndex];
        else
            dialogueBoxGameObject.SetActive(false);
    }
}
