using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIOptions : MonoBehaviour
{
    public Image healthbaroutline;
    public Image healthbar;

   public void ActivateUI()
    {
        healthbar.enabled = true;
        healthbaroutline.enabled = true;
    }

    public void DeactivateUI()
    {
        healthbar.enabled = false;
        healthbaroutline.enabled = false;
    }
}
