using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBar : MonoBehaviour
{
    public RectTransform bar;
    public GameObject player;

    void Start()
    {

    }

    public void UpdateStaminaBar()
    {
        bar.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, player.GetComponent<PlayerController>().stamina * 50);
    }

    public void UpdateHPBar()
    {
        bar.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, player.GetComponent<Combat>().health);
    }

    public void UISetactive()
    {
        gameObject.SetActive(true);
    }

    public void UISetInactive()
    {
        gameObject.SetActive(false);
    }
}
