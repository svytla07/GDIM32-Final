using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    // Start is called before the first frame update

   /* [SerializeField] Inventory _recipeList;
    [SerializeField] List<string> _ingredientCheck = new List<string>();
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray CatRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(CatRay, out RaycastHit hit))
            {
                if (hit.collider.CompareTag("StartManagerDialogue"))
                {
                    UnityEngine.Debug.Log("Click on cat");
                    //_ingredientCheck = _recipeList.DialogueInventory();
                    for (int i = 0; i < _managerOrder.order.Count; i++)
                    {
                        
                        for (int j = 0; j < _ingredientCheck.Count; j++)
                        {
                            UnityEngine.Debug.Log(_ingredientCheck[j]);
                            if (_ingredientCheck[j] == _managerOrder.order[i].ToString())
                            {
                                UnityEngine.Debug.Log("Success");
                            }
                        }
                        
                    }
                    
                    
                }
            }
        }
        


       



    } */
}
