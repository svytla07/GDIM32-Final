using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public static Dialogue Instance { get; private set; }


    private void Awake()
    {
    
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this; 
    }

   
}
