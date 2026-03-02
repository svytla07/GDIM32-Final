using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Item", menuName = "RumpledCode/Item", order = 1)]
public class Item : ScriptableObject
{
    public string id;
    public string description; 
    public Sprite icon; 
    public GameObject Prefab; 
}
