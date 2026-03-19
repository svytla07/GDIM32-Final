using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _npcText;
    [SerializeField] private GameObject _npcDialogue;
    [SerializeField] private GameObject _playerMultiOptions;
    [SerializeField] private TMP_Text _option1;
    [SerializeField] private TMP_Text _option2;


    public void ShowDialogue(string dialogue)
    {
        gameObject.SetActive(true);

        _npcDialogue.SetActive(true);
        _playerMultiOptions.SetActive(false);

        _npcText.text = dialogue;
    }
  
    public void ShowPlayerOptions(string[] options)
    {
        gameObject.SetActive(true);

        _npcDialogue.SetActive(false);
        _playerMultiOptions.SetActive(true);

        _option1.text = options[0];

        if(options.Length >= 2)
        {
            _option2.transform.parent.gameObject.SetActive(true);
            _option2.text = options[1];
        }
        else 
        {
            _option2.transform.parent.gameObject.SetActive(false);
        }

    }

    public void HideDialogue()
    {
      
        _npcDialogue.SetActive(false);
        gameObject.SetActive(false);
    }
}
