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
    [SerializeField] private float interactRange = 3f; 
    [SerializeField] private PlayerInteraction playerInteraction;

    void Start()
    {
        if (crosshairText == null)
            crosshairText = GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        
     if (playerInteraction != null && playerInteraction.IsLookingAtItem())
        {
            crosshairText.color = hoverColor;
        }
        else
        {
            crosshairText.color = normalColor;
        }
    }
}
