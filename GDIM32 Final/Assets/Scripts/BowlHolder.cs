using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlHolder : MonoBehaviour
{
    public static BowlHolder Instance {get; private set; }

    [SerializeField] private Transform _holdPoint;
    [SerializeField] private Camera _playerCamera;

    private GameObject _heldBowl;
    private bool _hasNoodles = false; 
    private bool _hasSoup = false; 

    public bool IsHoldingBowl => _heldBowl != null; 
    public bool HasNoodles => _hasNoodles;
    public bool HasSoup => _hasSoup;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void PickupBowl(GameObject bowlObject)
    {
        if (_heldBowl != null) return;

        _heldBowl = bowlObject;
        _heldBowl.transform.SetParent(_holdPoint);
        _heldBowl.transform.localPosition = Vector3.zero;
        _heldBowl.transform.localRotation = Quaternion.identity;

        Rigidbody rb = _heldBowl.GetComponent<Rigidbody>();
        if (rb != null) rb.isKinematic = true; 

        Collider col = _heldBowl.GetComponent<Collider>();
        if (col != null) col.enabled = false;
    }

    public void AddNoodles()
    {
        if (!IsHoldingBowl) return;
        _hasNoodles = true;
        Debug.Log("noodles hath been addth to the bowleth");
    }

    public void AddSoup()
    {
        if (!IsHoldingBowl || !_hasNoodles) return; 
        _hasSoup = true; 
        Debug.Log("soup in bowl yay");
        PhoComplete();
    }

    private void PhoComplete()
    {
        Debug.Log("PHO COMPLETE");

        Vector3 spawnPos = _playerCamera.transform.position
                        + _playerCamera.transform.forward * 1.5f;
        Recipe _currentRecipe = QuestManager.Instance?.GetCurrentRecipe();
        if (_currentRecipe != null && _currentRecipe.result != null)
        {
            Instantiate(_currentRecipe.result.prefab, spawnPos, Quaternion.identity);
        }
        QuestManager.Instance?.AdvanceQuest(); 
    }
    
    

}
