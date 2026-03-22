using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueController : MonoBehaviour
{
    [SerializeField] private float _interactionDistance = 10.0f;
    [SerializeField] private Sprite _interactionPromptSprite;
    [SerializeField] private Image _thoughtBubble; 
    [SerializeField] private DialogueUI _dialogue; 
    [SerializeField] private DialogueNode _dialogueStartNode; 

    private DialogueNode _currentNode; 
    private int _currentLine = 0; 
    public bool _runningDialogue;
    public bool _waitingForPlayerResponse;
    private Transform _player;

    private void Start()
    {
        _currentNode = _dialogueStartNode;
    }

    private void Update()
    {
        if (Dialogue.Instance == null) return;

         float dist = Vector3.Distance(transform.position, Dialogue.Instance.transform.position);

        if (dist < _interactionDistance)
        { if (Input.GetKeyDown(KeyCode.E) && !_waitingForPlayerResponse)
                AdvanceDialogue();
        }
        
        else
        {
            if (!_runningDialogue)
            {
                if (_thoughtBubble != null)
                _thoughtBubble.gameObject.SetActive(false);
            }
        }
    }

    public void SetStartNode(DialogueNode node)
    {
        _dialogueStartNode = node;
        _currentNode = node;
        _currentLine = 0; 
        
    }

    public void AdvanceDialogue()
    {
        Debug.Log($"AdvanceDialogue - line: {_currentLine}, total: {_currentNode._lines.Length}, choices: {_currentNode._playerChoices?.Length ?? 0}");
        if (!_runningDialogue)
        {
            _runningDialogue = true;
            BowlHolder.Instance?.DismissBowl();
            TriggerQuestAction(_currentNode);
        }
       
        if (_currentLine < _currentNode._lines.Length)
        {
            _dialogue.ShowDialogue(_currentNode._lines[_currentLine]);

            _currentLine++;
           
        }
        else if (_currentNode._playerChoices != null &&_currentNode._playerChoices.Length > 0)
        {
             Debug.Log("Showing choices!");
            _waitingForPlayerResponse = true;
            _dialogue.ShowPlayerOptions(_currentNode._playerChoices);

        }
        else 
        {
            EndDialogue();
        }
    }
    private void TriggerQuestAction(DialogueNode node)
    {
        switch (node.questAction)
        {
            case DialogueNode.QuestAction.StartGather:
            if (QuestManager.Instance.gatherIngredients.state == QuestState.NotStarted)
                QuestManager.Instance.SetQuest(QuestManager.Instance.gatherIngredients);
            break; 
            case DialogueNode.QuestAction.StartChickenPho:
                QuestManager.Instance.SetQuest(QuestManager.Instance.cookChickenPho);
                break;
            case DialogueNode.QuestAction.StartBeefPho:
                QuestManager.Instance.SetQuest(QuestManager.Instance.cookBeefPho);
                break;
        }
    }

    private void EndDialogue()
    {
        _runningDialogue = false; 
        _waitingForPlayerResponse = false;
        _currentNode = _dialogueStartNode;
        _currentLine = 0;
        _dialogue.HideDialogue();
        _thoughtBubble.gameObject.SetActive(false);
    }

    public void SelectedOption(int option)
    {
        _currentLine = 0;
        _waitingForPlayerResponse = false; 

        _currentNode = _currentNode._managerReplies[option];

        TriggerQuestAction(_currentNode);
        AdvanceDialogue();
    }
   
   
}
