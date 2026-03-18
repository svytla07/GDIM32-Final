using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Recipe", menuName = "RumpledCode/Recipe", order = 1)]
public class Recipe : ScriptableObject
{
    public List<Item> requiredIngredients;  
    public Item result;
    public float cooktime = 3f;
    public Color _resultcolor = Color.white;
}
