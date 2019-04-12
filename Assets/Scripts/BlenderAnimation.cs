using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void StartBlenderAnim(string animtrigger)
    {
        anim.SetTrigger(animtrigger);
    }
}
