using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Collider))]
public class Inventory : MonoBehaviour
{
    [Header("References")]
    [SerializeField] InventoryUI ui;
    [SerializeField] AudioSource audioSource; 

    [Header("audio clips")]
    [SerializeField] AudioClip pickUpItemAudio;

    [Header("State")]
    Dictionary<string, Item> inventory = new();
    public Item item; 
    public bool pickedUp; 
   
    void Start()
    {
        Initialize(item);
    }

    public void Initialize(Item item)
    {
        this.item = item; 
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ingredient"))
        {
            
            Inventory ingredientData = other.GetComponent<Inventory>(); 
            if (ingredientData == null || ingredientData.pickedUp) return;
            ingredientData.pickedUp = true; 
            AddItem(item);
            audioSource.PlayOneShot(pickUpItemAudio);
            Debug.Log("item picked up!"); 
        }
    }
    void AddItem(Item item)
    {
        var inventoryID = Guid.NewGuid().ToString();
        inventory.Add(inventoryID, item);
        ui.AddUIItem(inventoryID, item); 
    }
}
