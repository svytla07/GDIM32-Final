using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soup : MonoBehaviour
{
    [SerializeField] private Pot _pot;

    public void Interact()
    {
        BowlHolder holder = BowlHolder.Instance;
        
        if (_pot.CurrentState != PotState.Done)
        {
            Debug.Log("soup not done");
            return;
        }
        if (!holder.IsHoldingBowl)
        {
            Debug.Log("no bowl held");
        }

        if (!holder.HasNoodles)
        {
            Debug.Log("add noodles first");
            return;
        }

        holder.AddSoup();
    }
}
