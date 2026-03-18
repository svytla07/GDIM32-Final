using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using UnityEngine;

[CreateAssetMenu (fileName = "DialogueNode", menuName = "ScriptableObjects/DialogueNode")]
public class DialogueNode : ScriptableObject
{
    public string npcName;
    public string[] dialogueLines;
    public bool[] autoProgressLines;
    public bool[] endDialogueLines;
    
    public DialogueChoice[] choices;
}

[System.Serializable]
public class DialogueChoice {
    public int dialogueIndex;
    public string[] choices;
    public int[] nextDialogueIndexes;
}