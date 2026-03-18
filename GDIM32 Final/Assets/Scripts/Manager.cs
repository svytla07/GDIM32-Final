using System.Collections;
using System.Collections.Generic;
using UnityEngine.Android;
using UnityEngine;

public class Manager : MonoBehaviour
{
  [SerializeField] private DialogueNode _greetingDialogue;
  [SerializeField] private DialogueNode _gatheringDialogue;
  [SerializeField] private DialogueNode _chickenPhoDialogue;
  [SerializeField] private DialogueNode _beefPhoDialogue;
  [SerializeField] private DialogueNode _completedDialogue;

  private DialogueNode _currentNode; 
  private int _currentLineIndex = 0;

    public void Talk() 
    {
        
        Quest gather = QuestManager.Instance.gatherIngredients;
        Quest cookChicken = QuestManager.Instance.cookChickenPho;
        Quest cookBeef = QuestManager.Instance.cookBeefPho;

        if (gather.state == QuestState.NotStarted) 
        {
            QuestManager.Instance.SetQuest(gather);
        }
        else if (gather.state == QuestState.Completed && cookChicken.state == QuestState.NotStarted) 
        {
            QuestManager.Instance.SetQuest(cookChicken);
        }
        else if (gather.state == QuestState.Completed && cookChicken.state == QuestState.Completed && cookBeef.state == QuestState.NotStarted) 
        {
           QuestManager.Instance.SetQuest(cookBeef);
        }
    
    }

    private void StartDialogue(DialogueNode node)
    {
        _currentNode = node; 
        _currentLineIndex = 0; 
        DialogueController.Instance.ShowDialogueUI(true);
        DialogueController.Instance.SetNPCInfo(node.npcName);
        DialogueController.Instance.SetDialogueText(node.dialogueLines[0]);
    }

    public void NextLine()
    {
        if (_currentNode == null) return; 

        if (_currentNode.endDialogueLines[_currentLineIndex])
        {
            DialogueController.Instance.ShowDialogueUI(false);
            _currentNode = null;
            return; 
        }

        _currentLineIndex++;
        if(_currentLineIndex >= _currentNode.dialogueLines.Length)
        {
            DialogueController.Instance.ShowDialogueUI(false);
            _currentNode = null;
            return;
        }

        DialogueController.Instance.SetDialogueText(_currentNode.dialogueLines[_currentLineIndex]);

    }

    public bool IsDialogueOpen => _currentNode != null;
}
    



