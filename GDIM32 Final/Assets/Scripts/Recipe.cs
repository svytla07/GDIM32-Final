using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe : ScriptableObject
{
    public List<item> requiredIngredients; 

    public Item result;

    public float cooktime = 3f; 
}
