using System.Collections;
using System.Collections.Generic;
using UnityEngine.Android;
using UnityEngine;

public class Manager : MonoBehaviour
{
  
    public void Talk() {
        
        Quest gather = QuestManager.Instance.gatherIngredients;
        Quest cookChicken = QuestManager.Instance.cookChickenPho;
        Quest cookBeef = QuestManager.Instance.cookBeefPho;

        if (gather.state == QuestState.NotStarted) {
            gather.state = QuestState.InProgress;
        }
        if (gather.state == QuestState.Completed && cookChicken.state == QuestState.NotStarted) {
            cookChicken.state = QuestState.InProgress;
        }
        if (gather.state == QuestState.Completed && cookChicken.state == QuestState.Completed && cookBeef.state == QuestState.NotStarted) {
            cookBeef.state = QuestState.InProgress;
        }
    
    }
 
    
   
            
    
        
    
}
    



