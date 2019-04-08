using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss1Behaviour : MonoBehaviour
{
    public float lookRadius = 50f;

    public float closeRadius = 3f;
    public float midRadius = 10f;
    public float farRadius = 20f;

    Transform target;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector4.Distance(target.position, transform.position);

        if(distance <= lookRadius)
        {
            agent.SetDestination(target.position);
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
                //short attack 1 or 2
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
                //mid range attack
            }else if(decision <= 50)
            {
                //tackle towards player
            }
        }//if player is in long range
        else if(distance < farRadius)
        {
            if (decision > 50)
            {
                //long range attack
            }
            else if (decision <= 50)
            {
                //tackle towards player
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
