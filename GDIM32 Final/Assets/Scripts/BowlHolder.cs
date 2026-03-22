using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlHolder : MonoBehaviour
{
    public static BowlHolder Instance {get; private set; }

    [SerializeField] private Transform _holdPoint;
    [SerializeField] private Camera _playerCamera;
    [SerializeField] private GameObject _noodlesPrefab;
    [SerializeField] private GameObject _soupPrefab; 
    

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

        _hasNoodles = false; 
        _hasSoup = false;

        if(_holdPoint == null) 
        {  
            
            _holdPoint = GameObject.Find("HoldPoint")?.transform;

        
        }

        Vector3 spawnPos = _playerCamera.transform.position 
                     + _playerCamera.transform.forward * 0.8f;




        _heldBowl = Instantiate(bowlObject, spawnPos, Quaternion.identity);
        _heldBowl.transform.SetParent(_holdPoint ?? _playerCamera.transform);
        _heldBowl.transform.localPosition = Vector3.zero;
        _heldBowl.transform.localRotation = Quaternion.identity;
        _heldBowl.transform.localScale = bowlObject.transform.localScale; 

        Vector3 prefabScale = bowlObject.transform.lossyScale;
        _heldBowl.transform.SetParent(null);
        _heldBowl.transform.localScale = prefabScale;
        _heldBowl.transform.SetParent(_holdPoint ?? _playerCamera.transform);

        Rigidbody rb = _heldBowl.GetComponent<Rigidbody>();
        if (rb != null) rb.isKinematic = true; 

        Collider col = _heldBowl.GetComponent<Collider>();
        if (col != null) col.enabled = false;

        Debug.Log("bowl clone spawned in hand");
    }

    public void AddNoodles()
    {
        if (!IsHoldingBowl) return;
        _hasNoodles = true;
        Debug.Log("AddNoodles called, _hasNoodles set to true");
        

        if (_noodlesPrefab != null)
        {
            GameObject noodles = Instantiate(_noodlesPrefab, _holdPoint.position, _holdPoint.rotation);

            Vector3 prefabScale = _noodlesPrefab.transform.lossyScale;
            Quaternion prefabRotation = _noodlesPrefab.transform.rotation;

            noodles.transform.SetParent(null);
            noodles.transform.localScale = new Vector3(32, 32, 32);
            noodles.transform.rotation = prefabRotation; 
            noodles.transform.SetParent(_heldBowl.transform);
            noodles.transform.localPosition = new Vector3(0f, 0.7f, 0);

            Debug.Log($"Noodles position: {noodles.transform.position}, scale: {noodles.transform.localScale}");

        }
        Debug.Log("noodles hath been addth to the bowleth");
    }

    public void AddSoup()
    {
        if (!IsHoldingBowl || !_hasNoodles) return; 
        _hasSoup = true; 

        if (_soupPrefab != null)
        {
            GameObject soup = Instantiate(_soupPrefab);
            soup.transform.SetParent(_heldBowl.transform);
            soup.transform.position = _heldBowl.transform.position;
            soup.transform.localRotation = _soupPrefab.transform.localRotation;

            float bowlScale = _heldBowl.transform.lossyScale.x;
            float targetScale = 22f / bowlScale; 
            soup.transform.localScale = new Vector3(targetScale, targetScale, targetScale);
        }
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

        Debug.Log("manager dialogue moving forward");
    }
    
    

}
