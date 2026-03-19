using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using UnityEngine;

[CreateAssetMenu (fileName = "DialogueNode", menuName = "ScriptableObjects/DialogueNode")]
public class DialogueNode : ScriptableObject
{
    public string npcName;

    public Sprite _thoughtBubbleSprite;

    public string[] _lines;
    
    
    public string[] _playerChoices;

    public DialogueNode[] _managerReplies; 

    public enum QuestAction { None, StartGather, StartChickenPho, StartBeefPho }
    public QuestAction questAction = QuestAction.None;


}


