using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] GameObject uiItemPrefab;
 
    [SerializeField] Inventory inventory; 

    [SerializeField] Transform uiInventoryParent; 

    Dictionary<string, GameObject> inventoryUI = new(); 

    public void AddUIItem(string inventoryID, Item item)
    {
        var itemUI = Instantiate(uiItemPrefab).GetComponent<ItemUI>();
        itemUI.transform.SetParent(uiInventoryParent);
        inventoryUI.Add(inventoryID, itemUI.gameObject);
        itemUI.Initialize(inventoryID, item);
    }

}
