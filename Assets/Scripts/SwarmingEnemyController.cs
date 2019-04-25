using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SwarmingEnemyController : MonoBehaviour
{
    Transform target;
    NavMeshAgent nav;
    Animator animator;
    Rigidbody rb;
    Mutation mut;

    public float awareness = 20f;
    public float turnSpeed = 3f;
    public float attackrange = 5f;
    private float distance;
    public string triggerName;


    [SerializeField] private int maxStamina;
    public int stamina;

    private float stamtimer = 10f;

    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        if (GameObject.FindGameObjectWithTag("Player").transform != null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        mut = GetComponent<Mutation>();
    }

    void Update()
    {
        if(target == null)
        {
            
           
        }
        RegainStamina();
        distance = Vector3.Distance(target.position, transform.position);

        if (distance <= awareness)
        {
            FaceTarget();
            transform.LookAt(transform.position - target.position);
            nav.SetDestination(target.position);
        }

        if (distance <= attackrange)
        {
            Attack();
        }
    }
    
    private void RegainStamina()
    {
        if(stamina < maxStamina)
        {
            if(stamtimer <= 0)
            {
                stamina++;
                stamtimer = 10f;
            }
            else
            {
                stamtimer -= Time.deltaTime;
            }
        }
    }

    private void FaceTarget()
    {
        Vector3 targetPos = target.position - transform.position;
        targetPos.y = transform.position.y;
        transform.rotation = Quaternion.LookRotation(targetPos);
        //Quaternion currentrot = Quaternion.LookRotation(new Vector3(this.transform.position.x, 0, this.transform.position.z));
        //Vector3 direction = (target.position - transform.position).normalized;
        //Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        //transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, awareness);
    }

    public void Knockback(Vector3 Direction, int force)
    {
        rb.AddForce(Direction * force, ForceMode.Impulse);
    }

    public void Attack()
    {
        ClearAllTriggers();
        if (stamina > 3)
        {
            if (mut.rArmMutation == 0)
            {
                animator.SetTrigger("RA_Unmutated");
            }
            else if (mut.rArmMutation == 1)
            {
                animator.SetTrigger("RA_Defected");
            }
            else if (mut.rArmMutation == 2)
            {
                animator.SetTrigger("RA_Abberant");
            }
        }
    }

    private void ClearAllTriggers()
    {
        animator.ResetTrigger("RA_Unmutated");
        animator.ResetTrigger("RA_Defected");
        animator.ResetTrigger("RA_Abberant");
    }
}
