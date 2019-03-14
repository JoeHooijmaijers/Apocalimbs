using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    private Animator animator;
    public Mutation mut;

    public float movementSpeed;
    public float jumpHeight;
    public float rotationSpeed;

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

        Movement();

        if (Input.GetMouseButtonDown(0))
        {
            RightArmAttack();
        }

        if (Input.GetMouseButtonDown(2))
        {
            gameObject.GetComponent<Mutation>().MutateTemp();
        }

    }

    void Movement()
    {
        Vector3 targetDirection = new Vector3(Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime, 0f, Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime);
        targetDirection = Camera.main.transform.TransformDirection(targetDirection);
        targetDirection.y = 0.0f;
        transform.Translate(targetDirection, Space.World);
        if (targetDirection != new Vector3(0f, 0f, 0f))
        {
            transform.rotation = Quaternion.LookRotation(targetDirection);
        }
        if (Input.GetKey("space"))
        {
            Jump();
        }
    }

    void Jump()
    {
        bool IsGrounded = Physics.Raycast(transform.position, Vector3.down, distanceToGround + 0.0f);

        if (IsGrounded)
        {
            rb.velocity += jumpHeight * Vector3.up;
        }
    }

    void DodgeRoll()
    {
        animator.SetTrigger("DodgeRoll");
        Debug.Log("BBBB");
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

    }

    void LeftLegAttack()
    {

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
