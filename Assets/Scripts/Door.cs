using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject door;
    public Animator anim;

    private void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    void OpenDoor()
    {
        anim.SetTrigger("OpenDoor");
    }
}
