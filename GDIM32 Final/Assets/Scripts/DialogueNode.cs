using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using UnityEngine;

[CreateAssetMenu (fileName = "DialogueNode", menuName = "ScriptableObjects/NialogueNode")]
public class DialogueNode : ScriptableObject
{
    public List<string>_dialogueIntro;
    public List<string>_dialogueCorrect;
    public List<string>_dialogueIncorrect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
