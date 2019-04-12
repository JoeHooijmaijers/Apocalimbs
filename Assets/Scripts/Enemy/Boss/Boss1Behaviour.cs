﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss1Behaviour : MonoBehaviour
{
    public float lookRadius = 50f;

    public float closeRadius = 3f;
    public float midRadius = 10f;
    public float farRadius = 20f;

    [SerializeField]private bool canMove = true;
    [SerializeField]private bool canAttack = true;

    Transform target;
    NavMeshAgent agent;
    Animator anim;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector4.Distance(target.position, transform.position);

        if(distance <= lookRadius)
        {
            if (canMove == true)
            {
                agent.SetDestination(target.position);
            }
            if (canAttack)
            {
                NextMove();
            }
            
        }
    }

    private void NextMove()
    {
        int decision = Random.Range(1, 100);

        float distance = Vector4.Distance(target.position, transform.position);
        //if player is in close range
        if (distance < closeRadius)
        {
           if(decision > 60)
            {
                ShortAttack();
            } else if(decision <= 60 && decision > 30)
            {
                //strafe around player for ... seconds
            }else if(decision <= 30)
            {
                //backjump away to farRange distance
            }
 
        }//if player is in mid range
        else if(distance < midRadius)
        {
           if(decision > 50)
            {
                MidAttack();
            }else if(decision <= 50)
            {
                //tackle towards player
            }
        }//if player is in long range
        else if(distance < farRadius)
        {
            if (decision > 50)
            {
                FarAttack();
            }
            else if (decision <= 50)
            {
                //tackle towards player
            }
        }
    }

    public void Knockback(Vector3 Direction, int force)
    {
        rb.AddForce(Direction * force, ForceMode.Impulse);
    }

    private void ShortAttack()
    {

        anim.ResetTrigger("ShortAttack1");
        anim.ResetTrigger("ShortAttack2");
        anim.ResetTrigger("MidAttack1");
        anim.ResetTrigger("FarAttack1");
        int rnd = Random.Range(1, 3);
        if(rnd == 1)
        {
            anim.SetTrigger("ShortAttack1");
        }
        else
        {
            anim.SetTrigger("ShortAttack2");
        }
    }

    private void WalkAround()
    {

    }

    private void GapCloser()
    {
        anim.SetTrigger("Gapcloser");
    }

    private void MidAttack()
    {
        anim.SetTrigger("MidAttack1");
    }

    private void FarAttack()
    {
        anim.SetTrigger("FarAttack1");
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, closeRadius);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, midRadius);

    }
}