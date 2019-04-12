using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    Transform target;
    NavMeshAgent nav;
    Animator animator;
    Rigidbody rb;

    public float awareness = 6f;
    public float turnSpeed = 3f;
    private float distance;
    public string triggerName;

   
    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        distance = Vector3.Distance(target.position, transform.position);
       
        if (distance <= awareness)
        {
            FaceTarget();
            InRange(distance);
        }
    }

    private void InRange(float Distance)
    {
        if (Distance <= nav.stoppingDistance)
        {
            animator.SetTrigger(triggerName);
        }
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.transform == target)
        {
            Vector3 LastSeen = new Vector3(target.position.x, target.position.y, target.position.z);
            nav.SetDestination(LastSeen);
            InRange(distance);
        }
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

    public void Knockback(Vector3 Direction, int force)
    {
        rb.AddForce(Direction * force, ForceMode.Impulse);
        //###Doesn't work properly!### kinda
    }
}
