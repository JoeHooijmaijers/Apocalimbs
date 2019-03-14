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
    public float awareness = 6f;
    public float vision = 10f;
<<<<<<< HEAD
    public float turnSpeed = 3f;
    public float timeAirborne = 1f;
    private float distance;
=======
    public float turnSpeed = 5f;
    //Commented this out since it didn't work, sorry max
    //float distance = Vector3.Distance(target.position, transform.position);

    Transform target;
    NavMeshAgent agent;
>>>>>>> c324ed19ffca803140ee4a04b8e073196e35b453

    // Start is called before the first frame update
    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
<<<<<<< HEAD
    {
        distance = Vector3.Distance(target.position, transform.position);
       
        if (distance <= awareness)
        {
            Debug.Log("InRange");
            InRange(distance);
        }
=======
    {             
        //if (distance <= awareness)
        //{
        //    inRange();
            
        //}
>>>>>>> c324ed19ffca803140ee4a04b8e073196e35b453
    }

    private void InRange(float Distance)
    {
<<<<<<< HEAD
        Vector3 LastSeen = new Vector3(target.position.x, target.position.y, target.position.z);
        nav.SetDestination(LastSeen);
        FaceTarget();
        if (Distance <= nav.stoppingDistance)
        {
            //Lunge
            animator.SetTrigger("InLungeRange");
            Debug.Log("Lekker Lungen");
            //Face target
        }
=======
        //agent.SetDestination(target.position);
        //if (distance <= agent.stoppingDistance)
        //{
        //    //lunge

        //    //Face target
        //    FaceTarget();
        //}
>>>>>>> c324ed19ffca803140ee4a04b8e073196e35b453
    }

    private void Lunge()
    {
        transform.position = Vector3.Slerp(transform.position, new Vector3(target.position.x, target.position.y, target.position.z), Time.deltaTime * timeAirborne);
        
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.transform == target)
        {
            Vector3 LastSeen = new Vector3(target.position.x, target.position.y, target.position.z);
            nav.SetDestination(LastSeen);
            InRange(distance);
        }
        //Vector3 position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        //Vector3 cov = this.transform.forward;

        //if (Physics.Raycast(position, cov, vision))
        //{
        //    Debug.DrawLine(position, cov, Color.red);
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
}
