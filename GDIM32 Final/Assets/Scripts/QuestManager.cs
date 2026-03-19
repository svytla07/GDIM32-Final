using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance { get; private set; }

    [SerializeField] private Recipe _currentRecipe; 
    [SerializeField] private Recipe _chickenPhoRecipe;
    [SerializeField] private Recipe _beefPhoRecipe;
    


    public Quest gatherIngredients;
    public Quest cookChickenPho;
    public Quest cookBeefPho;

    public Quest _currentQuest;


    

    void Awake()
    {
        if (Instance == null)Instance = this;
        else Destroy(gameObject);

        gatherIngredients = new Quest("Gather Ingredients", 5);
        cookChickenPho = new Quest("Cook Chicken Pho", 1, _chickenPhoRecipe);
        cookBeefPho = new Quest("Cook Beef Pho", 1, _beefPhoRecipe);
    }

    public Recipe GetCurrentRecipe() => _currentRecipe;
    
    public void SetRecipe(Recipe recipe)
    {
        _currentRecipe = recipe;
        Debug.Log($"Quest recipe changed to: {recipe.name}");
    }

    public void SetQuest(Quest quest)
    {
        _currentQuest = quest; 
        _currentQuest.state = QuestState.InProgress;

        if (quest.recipe != null)
            FindObjectOfType<Pot>()?.UpdateRecipe(quest.recipe);


    }

    public void GatherIngredient()
    {
         gatherIngredients.AddProgress(1);
    }

    public void AdvanceQuest()
    {

        if (_currentQuest == cookChickenPho)
        {
            cookChickenPho.state = QuestState.Completed; 
            Debug.Log("chicken pho complete, talk to manager");
        }
        else if (_currentQuest == cookBeefPho)
        {
            cookBeefPho.state = QuestState.Completed;
            Debug.Log("beef pho complete, talk to manager");
        }

            Debug.Log("all quest complete");
    }

    public Quest GetNextPhoQuest()
    {
        if (cookChickenPho.state == QuestState.Completed)
        return cookBeefPho;
    else
        return cookChickenPho;
    }
}