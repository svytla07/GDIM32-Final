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

    public void AdvanceQuest()
    {
        if (_currentQuest == gatherIngredients)
            SetQuest(cookChickenPho);
        else if (_currentQuest == cookChickenPho)
            SetQuest(cookBeefPho);
        else
            Debug.Log("all quest complete");
    }
}