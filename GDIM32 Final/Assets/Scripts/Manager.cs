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
  [SerializeField] private Recipe _chickenPhoRecipe;
  [SerializeField] private Recipe _beefPhoRecipe; 
  [SerializeField] private Animator _animator;



  private DialogueNode _currentNode; 
  private DialogueController _dialogueController; 
  protected GameObject _heldBowl; 

  void Start()
  {
    _dialogueController = GetComponent<DialogueController>();
  }

    public void Talk() 
    {
        
        Quest gather = QuestManager.Instance.gatherIngredients;
        Quest cookChicken = QuestManager.Instance.cookChickenPho;
        Quest cookBeef = QuestManager.Instance.cookBeefPho;

        if (gather.state == QuestState.NotStarted) 
        {
            _dialogueController.SetStartNode(_greetingDialogue);
        }
        else if (gather.state == QuestState.InProgress)
        {
            _dialogueController.SetStartNode(_gatheringDialogue); //keep gathering
        }
        else if (gather.state == QuestState.Completed && cookChicken.state == QuestState.NotStarted && cookBeef.state == QuestState.NotStarted) 
        {
            Recipe current = QuestManager.Instance.GetCurrentRecipe();
    
            if (current == _chickenPhoRecipe)
            QuestManager.Instance.SetQuest(cookChicken);
            else if (current == _beefPhoRecipe)
            QuestManager.Instance.SetQuest(cookBeef);
            _dialogueController.SetStartNode(_chickenPhoDialogue);
    
        }
        else if (cookChicken.state == QuestState.Completed && cookBeef.state == QuestState.NotStarted) 
        {
            QuestManager.Instance.ResetQuest();
            Quest next = QuestManager.Instance.GetNextPhoQuest();
            QuestManager.Instance.SetQuest(next);
            _dialogueController.SetStartNode(_beefPhoDialogue);
        }
        else if (cookBeef.state == QuestState.Completed)
        {
            QuestManager.Instance.allQuestsComplete = true; 
            _dialogueController.SetStartNode(_completedDialogue);
            _animator.SetTrigger("Jump");
        }
        _dialogueController.AdvanceDialogue();
    }

   
    
}
    



