using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Créer Dialogue")]
public class Dialogue : ScriptableObject {
    [SerializeField] private List<string> dialogueLines;
    public List<string> DialogueLines => dialogueLines;
}