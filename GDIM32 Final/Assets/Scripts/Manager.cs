using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    // Start is called before the first frame update
    public enum Ingredients
    {
        Noodles, Beef, Chicken, Spices, Water, Sugar, Salt, Herbs
    }

    [SerializeField]  List<Ingredients> order = new List<Ingredients>();



    private Ingredients _order(int randomizedIngredients)
    {
        switch (randomizedIngredients)
        {
            default: return Ingredients.Noodles;
            case 1: return Ingredients.Beef;
            case 2: return Ingredients.Chicken;
            case 3: return Ingredients.Spices;
            case 4: return Ingredients.Water;
            case 5: return Ingredients.Sugar;
            case 6: return Ingredients.Herbs;
        }
    }


    void Start()
    {
        
        for (int i = 0; i < 4; i++)
        {
           int randomizedIngredients = Random.Range(0, 6);
           order.Add(_order(randomizedIngredients));

        }


    }

 
    
   
            
    
        
    
}
    


    // Update is called once per frame
   

