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

    [SerializeField] protected Recipe _targetRecipe;

    protected PotState _currentState = PotState.Empty;
    protected List<Item> _addedIngredients = new();
    protected MeshRenderer meshRenderer;
    protected Rigidbody _rigidbody;

    protected virtual void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    protected virtual void OnTriggerEnter(Collider collider)
    {
        if (_currentState != PotState.Empty) return;

        // 注意 Tag 大小写必须一致
        if (collider.CompareTag("Ingredient"))
        {
            var droppedItem = collider.GetComponent<DroppedItem>();

            // droppedItem == null 才应该 return
            if (droppedItem == null) return;

            OnIngredientTriggered(droppedItem); // ← 少了分号
        }
    }

    protected virtual void OnIngredientTriggered(DroppedItem droppedItem)
    {
        _addedIngredients.Add(droppedItem.item);
        Destroy(droppedItem.gameObject);

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
        yield return new WaitForSeconds(_targetRecipe.cooktime); // ← 少了分号

        _currentState = PotState.Done;
        _cookingUi.SetActive(false);
        _checkMark.SetActive(true);
    }
}
