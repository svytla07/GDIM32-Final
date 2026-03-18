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
    }
}
    



