using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    // Start is called before the first frame update
    
 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) & CompareTag("StartManagerDialogue"))
        {
            Ray CatRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            UnityEngine.Debug.Log("Click on cat");
        }
        


       



    }
}
