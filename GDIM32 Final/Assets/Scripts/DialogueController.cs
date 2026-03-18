using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueController : MonoBehaviour
{
    public static DialogueController Instance { get; private set;}
    
    public GameObject dialoguePanel;
    public TMP_Text dialogueText, nameText;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void ShowDialogueUI (bool show) {
        dialoguePanel.SetActive(show);
    }

    public void SetNPCInfo (string npcName) {
        nameText.text = npcName;
    }

    public void SetDialogueText (string text) {
        dialogueText.text = text;
    }


   
   
}
