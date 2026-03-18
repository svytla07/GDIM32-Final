using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Noodles : MonoBehaviour
{
    private bool _interacted = false; 
    
    public void Interact()
    {
        BowlHolder holder = BowlHolder.Instance;

        if(!holder.IsHoldingBowl)
        {
            Debug.Log("no bowl in hand bruh");
            return;
        }

        if(holder.HasNoodles)
        {
            Debug.Log("bowl already has noodles");
            return;
        }

        holder.AddNoodles();

        Debug.Log($"HasNoodles value: {holder.HasNoodles}");
    }

}
