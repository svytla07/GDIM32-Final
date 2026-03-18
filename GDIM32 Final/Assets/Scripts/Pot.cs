using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PotState { Empty, Cooking, Done }

public class Pot : MonoBehaviour
{
    [SerializeField] protected GameObject _cookingUi;
    [SerializeField] protected GameObject _checkMark;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _addIngredientSound;
    [SerializeField] private AudioClip _cookingSound;
    [SerializeField] private AudioClip _doneSound;
    [SerializeField] private MeshRenderer _cylinder;

    [SerializeField] protected Recipe _targetRecipe;

    protected PotState _currentState = PotState.Empty;
    protected List<Item> _addedIngredients = new();
    protected MeshRenderer meshRenderer;
    protected Rigidbody _rigidbody;

    protected virtual void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        meshRenderer = GetComponent<MeshRenderer>();

        if (_cookingUi != null) _cookingUi.SetActive(false);
        if (_cookingUi != null) _checkMark.SetActive(false);
        
    }

   void OnTriggerEnter(Collider other)
{
    Debug.Log($"=== POT TRIGGER === Object: {other.name}, Tag: {other.tag}, State: {_currentState}");

    if (_currentState != PotState.Empty)
    {
        Debug.LogWarning("Pot is not empty, rejecting item!");
        return;
    }

    if (other.CompareTag("Ingredient"))
    {
        Debug.Log("Tag matches Ingredient");
        
        DroppedItem droppedItem = other.GetComponent<DroppedItem>();
        
        if (droppedItem == null)
        {
            Debug.LogError($" NO DroppedItem component!");
            return;
        }
        
        Debug.Log("DroppedItem component found");
        
        if (droppedItem.item == null)
        {
            Debug.LogError($" DroppedItem.item is NULL!");
            return;
        }

        Debug.Log($"Item is {droppedItem.item.name}");
        Debug.Log("CALLING OnIngredientTriggered");
        
        OnIngredientTriggered(droppedItem);
        
        
    }
    else
    {
        Debug.LogWarning($"✗ Wrong tag: {other.tag}");
    }
}

void OnIngredientTriggered(DroppedItem droppedItem)
{
    Rigidbody rb = droppedItem.GetComponent<Rigidbody>();
    if (rb != null)
    {
        rb.isKinematic = true;
        Debug.Log("set rigidbody to kinematic");
    }

    _addedIngredients.Add(droppedItem.item);
    Debug.Log($"Added {droppedItem.item.name} to pot. Total: {_addedIngredients.Count}");
    
    Destroy(droppedItem.gameObject);
    Debug.Log("Destroy() called!");

    
    Debug.Log($"Checking recipe... Need {_targetRecipe?.requiredIngredients.Count}, Have {_addedIngredients.Count}");
    
    if (CheckRecipe())
    {
        Debug.Log(">>> RECIPE COMPLETE! STARTING COOKING <<<");
        StartCooking();
    }
    else
    {
        Debug.Log("Recipe not complete yet");
    }
}

    protected bool CheckRecipe()
    {
        if (_targetRecipe == null) return false;
        if (_addedIngredients.Count != _targetRecipe.requiredIngredients.Count) return false;

        var added = new List<Item>(_addedIngredients);

        foreach (var required in _targetRecipe.requiredIngredients)
        {
            var match = added.Find(i => i.id == required.id);

            if (match == null) return false;
            added.Remove(match);
        }

        return true;
    }

    protected void StartCooking()
    {
        _currentState = PotState.Cooking;
        _cookingUi.SetActive(true);
        StartCoroutine(CookingTimer());
    }

    private IEnumerator CookingTimer()
    {
        yield return new WaitForSeconds(_targetRecipe.cooktime); 

        _currentState = PotState.Done;
        _cookingUi.SetActive(false);
        _checkMark.SetActive(true);

        if (_cylinder != null)
            _cylinder.material.color = _targetRecipe._resultcolor;
    }
}
