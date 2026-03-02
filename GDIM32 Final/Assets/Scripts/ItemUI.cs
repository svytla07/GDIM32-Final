using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Button))]
public class ItemUI : MonoBehaviour
{
    [SerializeField] Image image; 
    [SerializeField] Button button;


    public void Initialize(string inventoryID, Item item)
    {
        image.sprite = item.icon; 
        transform.localScale = Vector3.one;

    }
}
