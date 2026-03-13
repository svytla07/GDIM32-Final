using System;
using System.Collections.Generic;
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
    [SerializeField] Dictionary<string, Item> inventory = new();

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
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

    void AddItem(Item item)
    {
        var inventoryId = Guid.NewGuid().ToString();
        inventory.Add(inventoryId, item);
        ui.AddUIItem(inventoryId, item);
    }

    public void DropItem(string inventoryId)
    {
        if (!inventory.TryGetValue(inventoryId, out Item item)) return;

        Vector3 spawnPosition = transform.position + transform.forward * 1f + Vector3.up * 0.5f;
        var droppedItemObj = Instantiate(item.prefab, spawnPosition, Quaternion.identity);

        var playerCollider = GetComponent<Collider>();
        var itemCollider = droppedItemObj.GetComponent<Collider>();
        Physics.IgnoreCollision(playerCollider, itemCollider);

        var droppedItem = droppedItemObj.GetComponent<DroppedItem>();
        droppedItem.Initialize(item);

        inventory.Remove(inventoryId);
        ui.RemoveUIItem(inventoryId);
        audioSource.PlayOneShot(dropItemAudio);
    }
}
