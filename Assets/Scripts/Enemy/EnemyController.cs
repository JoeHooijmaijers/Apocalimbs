using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float awareness = 6f;
    public float vision = 10f;
    public float turnSpeed = 5f;
    //Commented this out since it didn't work, sorry max
    //float distance = Vector3.Distance(target.position, transform.position);

    Transform target;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {             
        //if (distance <= awareness)
        //{
        //    inRange();
            
        //}
    }

    private void inRange()
    {
        //agent.SetDestination(target.position);
        //if (distance <= agent.stoppingDistance)
        //{
        //    //lunge

        //    //Face target
        //    FaceTarget();
        //}
    }

    private void FaceTarget()
    {
        Quaternion currentrot = Quaternion.LookRotation(new Vector3(this.transform.position.x, 0, this.transform.position.z));
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, awareness);
    }

    private void OnTriggerStay(Collider other)
    {
        Vector3 position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        Vector3 cov = this.transform.forward;

        if (Physics.Raycast(position, cov, vision))
        {
            Debug.DrawLine(position, cov, Color.red);
        }
    }
}
