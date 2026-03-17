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

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (_currentState != PotState.Empty) return;

        
        if (GetComponent<Collider>().CompareTag("Ingredient"))
        {
            var droppedItem = GetComponent<Collider>().GetComponent<DroppedItem>();

            
            if (droppedItem == null) return;

            OnIngredientTriggered(droppedItem);
        }
    }

    protected virtual void OnIngredientTriggered(DroppedItem droppedItem)
    {
        _addedIngredients.Add(droppedItem.item);
        Destroy(droppedItem.gameObject);

        if (_audioSource != null && _addIngredientSound != null)
        {
        _audioSource.PlayOneShot(_addIngredientSound);
        }

        Debug.Log($"Ingredients in pot: {_addedIngredients.Count}/{_targetRecipe.requiredIngredients.Count}");


        if (CheckRecipe())
            StartCooking();
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
    }
}
