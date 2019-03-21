using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    Animator anim;

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenDoor()
    {
        anim.SetTrigger("OpenDoor");
        
    }
}
