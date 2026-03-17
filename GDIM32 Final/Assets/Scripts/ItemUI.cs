using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ItemUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    Image image;
    [SerializeField]
    Button button;

    void Start()
    {
        if (button == null)
        {
            Debug.LogError("Button is null in ItemUI!");
        }
    }

    public void Initialize(string inventoryId, Item item, Action<string> removeItemAction)
    {
        image.sprite = item.icon;
        transform.localScale = Vector3.one;

        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() => { 
            Debug.Log($"BUTTON CLICKED! Item: {item.name}, ID: {inventoryId}");
            removeItemAction.Invoke(inventoryId);
         });
    }

    void OnDestroy()
    {
        button.onClick.RemoveAllListeners();
    }
}