using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum QuestState
{
    NotStarted,
    InProgress,
    Completed
}

public class Quest
{
    public string questName;
    public int requiredAmount;
    public int currentAmount;
    public QuestState state;
    public Recipe recipe;
   
    public Quest(string name, int required, Recipe recipe = null)
    {
        questName = name;
        requiredAmount = required;
        currentAmount = 0;
        state = QuestState.NotStarted;
        this.recipe = recipe; 
        
    }

    public void AddProgress(int amount)
    {
        if (state != QuestState.InProgress) return;

        currentAmount += amount;
        Debug.Log("amount reached: " + currentAmount);

        if (currentAmount >= requiredAmount)
        {
            Debug.Log("moving on from " + questName );
            state = QuestState.Completed;
        }
    }
}
