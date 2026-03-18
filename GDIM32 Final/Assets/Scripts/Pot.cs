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
    private Color _defaultColor;

    protected virtual void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        meshRenderer = GetComponent<MeshRenderer>();

        if (_cookingUi != null) _cookingUi.SetActive(false);
        if (_checkMark != null) _checkMark.SetActive(false);
        
        if (_cylinder != null) 
            _defaultColor = _cylinder.material.color;

        if (QuestManager.Instance != null)
        _targetRecipe = QuestManager.Instance.GetCurrentRecipe();
    }

   void OnTriggerEnter(Collider other)
{

    if (_currentState != PotState.Empty)
    {
        Debug.LogWarning("Pot is not empty, rejecting item!");
        return;
    }

    if (other.CompareTag("Ingredient"))
    {
        Debug.Log("Tag matches Ingredient");
        
        DroppedItem droppedItem = other.GetComponent<DroppedItem>();
        
        if (droppedItem == null || droppedItem.item == null) return;

        
       if (!droppedItem.Claim()) return;

    Debug.Log($"Item is {droppedItem.item.name}");
     Debug.Log("CALLING OnIngredientTriggered");
        
    OnIngredientTriggered(droppedItem);
    }
}
void OnIngredientTriggered(DroppedItem droppedItem)
{
    droppedItem.isInPot = true;

    Rigidbody rb = droppedItem.GetComponent<Rigidbody>();
    if (rb != null)
    {
        rb.isKinematic = true;
        Debug.Log("set rigidbody to kinematic");
    }

    _addedIngredients.Add(droppedItem.item);

         Debug.Log($"Added {droppedItem.item.name} to pot. Total: {_addedIngredients.Count}");
    
    
    Inventory inventory = FindObjectOfType<Inventory>();
    if (inventory != null)
    {
        AudioSource inventoryAudio = inventory.GetComponent<AudioSource>();
        if (inventoryAudio != null)
            inventoryAudio.Stop();
    }

    if (_audioSource != null && _addIngredientSound != null)
        _audioSource.PlayOneShot(_addIngredientSound);
    else 
        Debug.LogError("the add ingredient sound is nul...");
    
    Debug.Log($"Checking recipe... Need {_targetRecipe?.requiredIngredients.Count}, Have {_addedIngredients.Count}");

    Destroy(droppedItem.gameObject);

         Debug.Log("Destroy() called!");
    
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
        

        if (_cylinder != null)
            _cylinder.material.color = _targetRecipe._resultcolor;

            StartCoroutine(CookingTimer());

    }

    private IEnumerator CookingTimer()
    {
        Debug.Log("CookingTimer coroutine started!");
        yield return new WaitForSeconds(_targetRecipe.cooktime); 
        Debug.Log("Timer finished! Setting state to Done...");

        _currentState = PotState.Done;
        _cookingUi.SetActive(false);
        _checkMark.SetActive(true);

        
        
        QuestManager.Instance?.AdvanceQuest();
    }
    
    public void UpdateRecipe(Recipe newRecipe)
    {
        _targetRecipe = newRecipe;
        _currentState = PotState.Empty;
        _addedIngredients.Clear();
        if(_checkMark != null) _checkMark.SetActive(false);
        if (_cylinder != null) _cylinder.material.color = _defaultColor;
    }
}
