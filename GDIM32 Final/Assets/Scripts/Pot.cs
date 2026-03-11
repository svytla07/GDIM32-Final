using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PotState { Empty, Cooking, Done }

public class Pot : MonoBehaviour
{
    [SerializeField] protected GameObject _cookingUi;
    [SerializeField] protected GameObject _checkMark;
    [SerializeField] protected Sprite _potEmpty;
    [SerializeField] protected Sprite _potWithSoup;

    protected PotState _currentState = PotState.Empty;

    protected MeshRenderer meshRenderer;
    protected Rigidbody _rigidbody;

    protected virtual void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        meshRenderer = GetComponent<MeshRenderer>();

    
    }

   // protected virtual void OnTriggerEnter(Collider collider)
    //{
       // if (other.CompareTag("ingredient"))
        //{
           // OnIngredientTriggered()
      //  }
  //  }

    //protected virtual void OnIngredientTriggered()
   // {
        

   // }
}
