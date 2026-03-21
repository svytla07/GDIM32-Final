using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Crosshair : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI crosshairText;
    [SerializeField] private Color normalColor = Color.white;
    [SerializeField] private Color hoverColor = Color.green; 
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float interactRange = 5f; 
    [SerializeField] private PlayerInteraction playerInteraction;

    void Start()
    {
        if (crosshairText == null)
            crosshairText = GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        bool isInteractable = false;
     if (playerInteraction != null && playerInteraction.IsLookingAtItem())
        {
            crosshairText.color = hoverColor;
        }
        else
        {
            crosshairText.color = normalColor;

        }

        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        if (Physics.Raycast(ray, out RaycastHit hit, interactRange))
        {
            

            DroppedItem droppedItem = hit.collider.GetComponent<DroppedItem>() 
                           ?? hit.collider.GetComponentInParent<DroppedItem>();


            if (hit.collider.GetComponent<Noodles>() != null
            || hit.collider.GetComponent<Soup>() != null 
            || hit.collider.GetComponent<Bowl>() != null 
            || hit.collider.GetComponent<DroppedItem>() != null
            || hit.collider.GetComponentInParent<DroppedItem>() != null
            )
                isInteractable = true;
        }
        crosshairText.color = isInteractable ? hoverColor : normalColor;
    }
}
