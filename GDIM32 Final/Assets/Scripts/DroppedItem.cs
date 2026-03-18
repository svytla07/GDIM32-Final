using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class DroppedItem : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField]
    bool autoStart;

    [SerializeField]
    float enabledPickupDelay = 3.0f;

    [Header("State")]
    public Item item;
    public bool pickedUp = false;

    void Start()
    {
         Rigidbody rb = GetComponent<Rigidbody>();

         if (rb != null)
         {
            rb.useGravity = true;
            rb.isKinematic = false;
        }
        if (autoStart && item != null)
        {
            Initialize(item);
        }
    }

    public void Initialize(Item item)
    {
        this.item = item;
        if (!autoStart && item.prefab != null)
        {
            var droppedItem = Instantiate(item.prefab, transform);
            droppedItem.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);

            DroppedItem childDroppedItem = droppedItem.GetComponent<DroppedItem>();
            if (childDroppedItem != null)
            {
                childDroppedItem.item = item;
            }
             
            Rigidbody rb = droppedItem.GetComponent<Rigidbody>();
             
            if (rb != null)
            {
                rb.useGravity = true;
                rb.isKinematic = false;
            }
        }


        
        if (!autoStart)
        {
            GetComponent<Collider>().enabled = false; 
            
        }
        StartCoroutine(EnablePickup(enabledPickupDelay));
    }

    IEnumerator EnablePickup(float delay)
    {
        yield return new WaitForSeconds (delay);
        GetComponent<Collider>().enabled = true;
       
    }
}
