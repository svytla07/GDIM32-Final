using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientSpawner : MonoBehaviour
{
    public static IngredientSpawner Instance { get; private set; }

    [SerializeField] private List<GameObject> _ingredients = new();

    [SerializeField] private List<Vector3> _startPositions = new();
    [SerializeField] private List<Quaternion> _startRotations = new();

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        foreach (var ingredient in _ingredients)
        {
            _startPositions.Add(ingredient.transform.position);
            _startRotations.Add(ingredient.transform.rotation);
        }
    }

    public void RespawnAll()
    {
        for (int i = 0; i < _ingredients.Count; i++)
        {
            if (_ingredients[i] != null)
            {
                _ingredients[i].transform.position = _startPositions[i];
                _ingredients[i].transform.rotation = _startRotations[i];

                
                _ingredients[i].SetActive(true);

                Rigidbody rb = _ingredients[i].GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.velocity = Vector3.zero;
                    rb.angularVelocity = Vector3.zero;
                }
            }
        }

        Debug.Log("ingredients respawned!");
    }
}
