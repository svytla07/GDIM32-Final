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

    void Start()
    {
        if (crosshairText == null)
            crosshairText = GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        if (playerCamera == null) return; 

        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        if(Physics.Raycast(ray, out RaycastHit hit, interactRange))
        {
            if(hit.collider.CompareTag("DroppedItem") || hit.collider.CompareTag("Ingredient"))
            {
                crosshairText.color = hoverColor;
            }
        }

        crosshairText.color = normalColor; 
    }
}
