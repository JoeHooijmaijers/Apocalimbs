using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPopups : MonoBehaviour
{
    //Interaction text that pops up when a player can perform an action
    [SerializeField]  private Text interactionText;

    private void Start()
    {
        HideInteractionText();
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
}
