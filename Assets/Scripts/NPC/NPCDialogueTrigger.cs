using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NPCDialogueTrigger : MonoBehaviour
{
    
    [SerializeField] private DialogueText dialogue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

}