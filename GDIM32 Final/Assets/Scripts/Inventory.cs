using System;
using System.Collections;
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

  

   public void AddItem(Item item)
    {
        var inventoryId = Guid.NewGuid().ToString();
       

         if (inventory.Values.Any(i => i.name == item.name))
        {
        Debug.LogWarning($"Item {item.name} already in inventory, skipping duplicate");
        return;
        }

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
        droppedItemObj.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        droppedItemObj.tag = "Ingredient";
        
        droppedItemObj.transform.localScale = item.dropScale;

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

        StartCoroutine(PlayDropSoundIfNotInPot(droppedItemObj));
    }

    IEnumerator PlayDropSoundIfNotInPot(GameObject droppedItem)
    {
        yield return new WaitForSeconds(0.3f);

        if (droppedItem != null)
        {
            DroppedItem droppedItemComponent = droppedItem.GetComponent<DroppedItem>();
            if (droppedItem != null && droppedItemComponent.isInPot)
            {
                yield break;
            }
            if (audioSource != null && dropItemAudio != null)
                audioSource.PlayOneShot(dropItemAudio);
        }



    }
    public List<string> DialogueInventory()
    {
        List<string> output = new List<string>();
        output = inventory.Values.Select(Item => Item.description).ToList();
        return output;
    }
}
