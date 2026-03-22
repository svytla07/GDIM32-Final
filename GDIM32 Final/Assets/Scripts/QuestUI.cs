using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestUI : MonoBehaviour
{
    [SerializeField] private TMP_Text questText;
    
   
    void Update()
    {
        if (QuestManager.Instance == null) return;
         if (QuestManager.Instance.gatherIngredients == null) return;
         if (QuestManager.Instance.cookChickenPho == null) return;
        if (QuestManager.Instance.cookBeefPho == null) return;

        var gather = QuestManager.Instance.gatherIngredients;
        var cookChicken = QuestManager.Instance.cookChickenPho; 
        var cookBeef = QuestManager.Instance.cookBeefPho;

        if (QuestManager.Instance.allQuestsComplete)
            questText.text = "All quests complete! YAY";


        else if (gather.state == QuestState.NotStarted)
        
            questText.text = " ";
        //second gather quest here 
       
        else if (gather.state == QuestState.InProgress && cookChicken.state == QuestState.Completed)
            
                questText.text = "Gather Ingredients: " + gather.currentAmount + "/" + gather.requiredAmount;  
            
        if (gather.state == QuestState.InProgress) // first gather quest
        
            questText.text = "Gather Ingredients: " + gather.currentAmount + "/" + gather.requiredAmount;
        
        else if (gather.state == QuestState.Completed && cookChicken.state == QuestState.InProgress)
        
            questText.text = "Cook the Chicken Pho";

        else if (cookChicken.state == QuestState.Completed && cookBeef.state == QuestState.NotStarted)
        
            questText.text = "Serve your pho to the manager!";

        else if (cookBeef.state == QuestState.InProgress)
            questText.text = "Cook the Beef Pho";

        
        
        else if (cookBeef.state == QuestState.Completed && cookChicken.state == QuestState.NotStarted)
        
            questText.text = "Talk to the manager to get started! ";

        
        
        else if (cookBeef.state == QuestState.Completed)
            questText.text = "all quests complete -- serve pho to manager";
          
    
    }
}
