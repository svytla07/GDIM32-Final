using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
   
    [SerializeField] private float interactRange = 3f;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private Inventory inventory;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip pickUpItemAudio;

    private DroppedItem currentLookingAt; 
    private Bowl _currentBowl;

    void Update()
    {
        
        CheckForItem();

        
        if (Input.GetMouseButtonDown(0))
        {

            if (_currentBowl != null)
            {
                 BowlHolder.Instance.PickupBowl(_currentBowl.gameObject);
                _currentBowl = null; 
                return; 

            }
            if (currentLookingAt != null)
            {   
                 PickupItem(currentLookingAt);
                return;
            }
        
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        if (Physics.Raycast(ray, out RaycastHit hit, interactRange))
        {

            Noodles noodles = hit.collider.GetComponent<Noodles>();
            if (noodles != null) { noodles.Interact(); return; }

            Soup soup = hit.collider.GetComponent<Soup>();
            if (soup != null) { soup.Interact(); return; }
        }
        }

    }

    void CheckForItem()
    {

        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        Debug.DrawRay(ray.origin, ray.direction * interactRange, Color.red);
        if (Physics.Raycast(ray, out RaycastHit hit, interactRange))
        {
            Debug.Log($"Hit: {hit.collider.name}");


            Bowl bowl = hit.collider.GetComponent<Bowl>()
                            ?? hit.collider.GetComponentInParent<Bowl>();
            if (bowl != null)
            {
                currentLookingAt = null;
                _currentBowl = bowl;
                return;
            }
            if (hit.collider.CompareTag("Ingredient") || hit.collider.CompareTag("DroppedItem"))
            {
                Debug.Log("tag matches");
                DroppedItem droppedItem = hit.collider.GetComponent<DroppedItem>()
                        ?? hit.collider.GetComponentInParent<DroppedItem>();


                if (droppedItem != null && !droppedItem.pickedUp)
                {
                    currentLookingAt = droppedItem;
                    _currentBowl = null;
                    return;
                }

                
            }
        }
        currentLookingAt = null;
        _currentBowl = null; 
    }

    void PickupItem(DroppedItem droppedItem)
    {
        if (droppedItem == null || droppedItem.pickedUp) return;

        Debug.Log($"Picking up: {droppedItem.item.name}");

        droppedItem.pickedUp = true;
        inventory.AddItem(droppedItem.item);
        Destroy(droppedItem.gameObject);

        if (audioSource && pickUpItemAudio)
            audioSource.PlayOneShot(pickUpItemAudio);

        currentLookingAt = null;
    }

    public bool IsLookingAtItem()
    {
        return currentLookingAt != null;
    }
}


