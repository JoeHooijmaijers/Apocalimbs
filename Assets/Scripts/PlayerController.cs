using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    private Animator animator;
    public Mutation mut;

    public PlayerStats stats;

    //public float movementSpeed;
    //public float jumpHeight;
    //public float rotationSpeed;
    //public float dodgerollSpeed;

    private float invincibletime;
    private float stuntime;

    float distanceToGround;


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mut = gameObject.GetComponent<Mutation>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceToGround = GetComponent<Collider>().bounds.extents.y;

        if(stuntime <= 0)
        {
            Movement();
            if (Input.GetMouseButtonDown(0))
            {
                RightArmAttack();
            }

            if (Input.GetMouseButtonDown(2))
            {
                //gameObject.GetComponent<Mutation>().MutateTemp();
            }

            if (Input.GetKeyDown(KeyCode.C))
            {
                DodgeRoll();
            }
        }
        else
        {
            stuntime -= Time.deltaTime;
        }

        if(invincibletime >= 0)
        {
            invincibletime -= Time.deltaTime;
        }
        stats.rollSpeed--;

    }

    void Movement()
    {
        Vector3 targetDirection = new Vector3(Input.GetAxis("Horizontal") * stats.movementSpeed * Time.deltaTime, 0f, Input.GetAxis("Vertical") * stats.movementSpeed * Time.deltaTime);
        targetDirection = Camera.main.transform.TransformDirection(targetDirection);
        targetDirection.y = 0.0f;
        transform.Translate(targetDirection, Space.World);
        if (targetDirection != new Vector3(0f, 0f, 0f))
        {
            var targetRotation = Quaternion.LookRotation(targetDirection);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, stats.RotationSpeed * Time.deltaTime);
        }
        //if (Input.GetKey("space"))
        //{
        //    Jump();
        //}
        
        

    }

    //void Jump()
    //{
    //    bool IsGrounded = Physics.Raycast(transform.position, Vector3.down, distanceToGround + 0.0f);

    //    if (IsGrounded)
    //    {
    //        rb.velocity += jumpHeight * Vector3.up;
    //    }
    //}

    void DodgeRoll()
    {
        if(Input.GetAxis("Horizontal") !=0 || Input.GetAxis("Vertical") != 0)
        {
            //RollDirection
            Vector3 targetDirection = new Vector3(Input.GetAxis("Horizontal") * stats.rollSpeed * Time.deltaTime, 0f, Input.GetAxis("Vertical") * stats.rollSpeed * Time.deltaTime);
            targetDirection = Camera.main.transform.TransformDirection(targetDirection);
            targetDirection.y = 0.0f;
            //directional dodgeroll costing 1 Radpoint
            rb.AddForce(targetDirection, ForceMode.VelocityChange);
            //transform.Translate(targetDirection, Space.World);
            invincibletime = 0.5f;
            stuntime = 0.8f;
            
        }
        else
        {
            //quick, short distance backstep costing no Radpoints
        }
    }

    public void Knockback(Vector3 Direction)
    {
        rb.AddForce(Direction* 6, ForceMode.Impulse);
        invincibletime = 1.0f;
    }

    void RightArmAttack()
    {
        
        if(mut.rArmMutation == 0)
        {
            animator.SetTrigger("RightArmAttackUnmutated");
        }
        else if (mut.rArmMutation == 1 && IsPlaying(animator, "RightArm_Attack_Defected"))
        {
            animator.SetTrigger("RightArmAttackDefected2");
        }
        else if(mut.rArmMutation == 1)
        {
            animator.SetTrigger("RightArmAttackDefected");
        }
    }

    void LeftArmAttack()
    {

    }

    void RightLegAttack()
    {
        //won't be implemented due to time constraints
    }

    void LeftLegAttack()
    {
        //won't be implemented due to time constraints
    }

    bool IsPlaying(Animator anim, string stateName)
    {
        if ((anim.GetCurrentAnimatorStateInfo(0).IsName(stateName) && anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f))
        {
            return true;
        }
        else
        {
            return false;
        }      
    }
}
