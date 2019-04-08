using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NPCDialogueTrigger : MonoBehaviour
{
    private int talkedTo;
    [SerializeField] private List<DialogueText> dialogues;

    // Start is called before the first frame update
    void Start()
    {
        talkedTo = 0;
    }

    public void TriggerDialogue()
    {
        if(talkedTo > dialogues.Count - 1)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogues[dialogues.Count]);
        }
        else
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogues[talkedTo]);
        }
        talkedTo++;
    }

}