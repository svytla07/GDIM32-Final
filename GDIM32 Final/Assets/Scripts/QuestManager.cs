using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance;

    public Quest gatherIngredients;
    public Quest cookChickenPho;
    public Quest cookBeefPho;

    void Awake()
    {
        Instance = this;

        gatherIngredients = new Quest("Gather Ingredients", 5);
        cookChickenPho = new Quest("Cook Chicken Pho", 1);
        cookBeefPho = new Quest("Cook Beef Pho", 1);
    }
}