using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    Animator anim;
    public TriggerState state;

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    public void OpenDoor()
    {
        anim.SetTrigger("OpenDoor"); 
    }

    public void DoorState()
    {
        if (state.cleared == true)
        {
            anim.SetTrigger("OpenDoor");
            anim.SetBool("IsOpen", true);
        }
        else
        {
            anim.SetBool("IsOpen", false);
        }
    }
}
