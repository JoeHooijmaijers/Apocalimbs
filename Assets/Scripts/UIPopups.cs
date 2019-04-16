using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPopups : MonoBehaviour
{
    //Interaction text that pops up when a player can perform an action
    [SerializeField]  private Text interactionText;

    //Dialoguebox that pops up when a player talks to an NPC
    //[SerializeField] private RectTransform textPanel;
    [SerializeField] private Text dialogueName;
    [SerializeField] private Text dialogueText;
    [SerializeField] private Button continueButton;

    private void Start()
    {
        HideInteractionText();
        HideDialogue();
    }

    public void ShowInteractionText(string text)
    {
        interactionText.enabled = true;
        interactionText.text = text;
    }

    public void HideInteractionText()
    {
        interactionText.enabled = false;
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
