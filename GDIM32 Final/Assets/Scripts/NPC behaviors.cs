using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    // Start is called before the first frame update
    public enum Ingredients
    {
        Noodles, Beef, Chicken, Spices, Water, Sugar, Salt, Herbs
    }

    public class customerOrder
    {
        private Ingredients _order;
        
      
   
           


    }


    void Start()
    {
        int usedIngredients = 0;
        for (int i = 0; i < 4; i++)
        {
            int randomizedusedIngredients = Random.Range(1, 7);
            Debug.Log(Random.Range(1, 7));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
