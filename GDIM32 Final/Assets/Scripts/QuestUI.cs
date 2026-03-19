using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestUI : MonoBehaviour
{
    [SerializeField] private TMP_Text questText;
    
   
    void Update()
    {
        var gather = QuestManager.Instance.gatherIngredients;
        var cookChicken = QuestManager.Instance.cookChickenPho; 
        var cookBeef = QuestManager.Instance.cookBeefPho;

        if (gather.state == QuestState.NotStarted)
        {
            questText.text = " ";
            return;
        }

          if (gather.state == QuestState.InProgress)
        
            questText.text = "Gather Ingredients: " + gather.currentAmount + "/" + gather.requiredAmount;
        
        else if (gather.state == QuestState.Completed && cookChicken.state == QuestState.InProgress)
        
            questText.text = "Cook the Chicken Pho";
        
        else if (gather.state == QuestState.Completed && cookBeef.state == QuestState.InProgress)
        
            questText.text = "Cook the Beef Pho";
        
        else if (cookChicken.state == QuestState.Completed && cookBeef.state == QuestState.NotStarted)
        
            questText.text = "Talk to the manager for your next task!";
        
        else if (cookBeef.state == QuestState.Completed && cookChicken.state == QuestState.NotStarted)
        
            questText.text = "Talk to the manager to get started! ";
        
        else if (cookChicken.state == QuestState.Completed && cookBeef.state == QuestState.Completed)
            questText.text = "All quests complete!";
    
    }
}
