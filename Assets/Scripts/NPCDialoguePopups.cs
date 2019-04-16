using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCDialoguePopups : MonoBehaviour
{
    //Dialoguebox that pops up when a player talks to an NPC
    [SerializeField] private RectTransform textPanel;
    [SerializeField] private Text dialogueName;
    [SerializeField] private Text dialogueText;
    [SerializeField] private Button continueButton;

    private void Start()
    {
        HideDialogue();
    }

    public void HideDialogue()
    {
        dialogueName.enabled = false;
        dialogueText.enabled = false;
        continueButton.enabled = false;
    }

    public void ShowDialogue()
    {
        dialogueName.enabled = true;
        dialogueText.enabled = true;
        continueButton.enabled = true;
    }

}
