using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class DroppedItem : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField]
    bool autoStart;

    [SerializeField]
    float enabledPickupDelay = 0f;

    [Header("State")]
    public Item item;
    public bool pickedUp = false;
    public bool isInPot = false; 
    private bool _isBeingDestroyed = false; 

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

    public void EnableForPotDetection()
    {
        GetComponent<Collider>().enabled = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pot"))
        {
            Pot pot = other.GetComponent<Pot>();
            if (pot != null)
                GetComponent<Collider>().enabled = true;
        }
    }
    public bool Claim()
    {
        if (_isBeingDestroyed) return false; 
        _isBeingDestroyed = true;
        return true;
    }
}
