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

    public Quest(string name, int required)
    {
        questName = name;
        requiredAmount = required;
        currentAmount = 0;
        state = QuestState.NotStarted;
    }

    public void AddProgress(int amount)
    {
        if (state != QuestState.InProgress) return;

        currentAmount += amount;

        if (currentAmount >= requiredAmount)
        {
            state = QuestState.Completed;
        }
    }
}
