using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Recipe", menuName = "RumpledCode/Recipe", order = 1)]
public class Recipe : ScriptableObject
{
    public List<Item> requiredIngredients;  // ← 修复大小写
    public Item result;
    public float cooktime = 3f;
}
