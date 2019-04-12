using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlenderAnimation : MonoBehaviour
{
    private Animator[] anim;
    private void Start()
    {
        anim = GetComponentsInChildren<Animator>();
    }


    public void StartBlenderAnim(string animtrigger)
    {
        foreach(Animator ani in anim)
        {
            ani.SetTrigger(animtrigger);
        }
       
    }
}
