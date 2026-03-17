using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [Header("References")]
    [SerializeField] InventoryUI ui;
    [SerializeField] AudioSource audioSource;

    [Header("Prefabs")]
    [SerializeField] GameObject droppedItemPrefab;

    [Header("Audio Clips")]
    [SerializeField] AudioClip pickUpItemAudio;
    [SerializeField] AudioClip dropItemAudio;

    [Header("State")]
    [SerializeField] public Dictionary<string, Item> inventory = new();

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.CompareTag("DroppedItem"))
                {
                    var droppedItem = hit.collider.GetComponent<DroppedItem>();
                    if (droppedItem == null) return;
                    if (droppedItem.pickedUp) return;

                    droppedItem.pickedUp = true;
                    AddItem(droppedItem.item);
                    Destroy(hit.collider.gameObject);
                    audioSource.PlayOneShot(pickUpItemAudio);
                }
            }
        }
    }

   public void AddItem(Item item)
    {
        var inventoryId = Guid.NewGuid().ToString();
        inventory.Add(inventoryId, item);
        ui.AddUIItem(inventoryId, item);
        Debug.Log(inventoryId);
    }

    public void DropItem(string inventoryId)
    {
        Debug.Log($"DropItem called with ID: {inventoryId}");

        if (!inventory.TryGetValue(inventoryId, out Item item)) return;
        
         Camera mainCam = Camera.main;
        Vector3 spawnPosition = mainCam.transform.position + mainCam.transform.forward * 2f;



        var droppedItemObj = Instantiate(item.prefab, spawnPosition, Quaternion.identity);
        droppedItemObj.transform.localScale = Vector3.one;
        droppedItemObj.tag = "Ingredient";

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player!= null)
        {
             var playerCollider = GetComponent<Collider>();
              var itemCollider = droppedItemObj.GetComponent<Collider>();
            if (playerCollider != null && itemCollider != null)
              Physics.IgnoreCollision(playerCollider, itemCollider, false);

        }
        
        var droppedItem = droppedItemObj.GetComponent<DroppedItem>();
        droppedItem.Initialize(item);
        
        inventory.Remove(inventoryId);
        ui.RemoveUIItem(inventoryId);
        audioSource.PlayOneShot(dropItemAudio);
    }
    public List<string> DialogueInventory()
    {
        List<string> output = new List<string>();
        output = inventory.Values.Select(Item => Item.description).ToList();
        return output;
    }
}
