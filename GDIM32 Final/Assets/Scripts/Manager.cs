using System.Collections;
using System.Collections.Generic;
using Unity.Android.Types;
using UnityEngine;

public class Manager : MonoBehaviour
{
    // Start is called before the first frame update
    public enum Ingredients
    {
        Noodles, Beef, Chicken, Onion, Water, Sugar, Salt
    }

    [SerializeField] public List<Ingredients> order = new List<Ingredients>();



    private Ingredients _order(int randomizedIngredients)
    {
        switch (randomizedIngredients)
        {
            default: return Ingredients.Beef;
            case 1: return Ingredients.Noodles;
            case 2: return Ingredients.Salt;
            case 3: return Ingredients.Onion;
            case 4: return Ingredients.Water;
            case 5: return Ingredients.Sugar;
            case 6: return Ingredients.Chicken;
        }
    }


    void Start()
    {
        int randomizedIngredients = Random.Range(-1,1);
        for (int i = 0; i < 6; i++)
        {
            
           randomizedIngredients = randomizedIngredients + 1; 
           order.Add(_order(randomizedIngredients));

        }


    }

 
    
   
            
    
        
    
}
    



