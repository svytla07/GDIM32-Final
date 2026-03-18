using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance { get; private set; }

    [SerializeField] private Recipe _currentRecipe; 

    public Quest gatherIngredients;
    public Quest cookChickenPho;
    public Quest cookBeefPho;

    void Awake()
    {
        if (Instance == null)Instance = this;
        else Destroy(gameObject);

        gatherIngredients = new Quest("Gather Ingredients", 5);
        cookChickenPho = new Quest("Cook Chicken Pho", 1);
        cookBeefPho = new Quest("Cook Beef Pho", 1);
    }

    public Recipe GetCurrentRecipe() => _currentRecipe;
    
    public void SetRecipe(Recipe recipe)
    {
        _currentRecipe = recipe;
        Debug.Log($"Quest recipe changed to: {recipe.name}");
    }
}