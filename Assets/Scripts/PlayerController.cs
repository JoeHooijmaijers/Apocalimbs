using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    private Animator animator;

    public GameEvent playerUsesStamina;
    public GameEvent playerRegainsStamina;

    public Mutation mut;
    public PlayerStats stats;

    public int stamina;
    [SerializeField] private float stamTimer;
    [SerializeField] private int maxStamina;

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

            if (Input.GetMouseButtonDown(1))
            {
                LeftArmAttack();
                Becomeinvisible();
            }

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

        if(stamina < maxStamina)
        {
            RegainStamina();
        }

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
    }

    void DodgeRoll()
    {
        if(Input.GetAxis("Horizontal") !=0 || Input.GetAxis("Vertical") != 0)
        {
            if(stamina >= 1)
            {
                //RollDirection
                Vector3 targetDirection = new Vector3(Input.GetAxisRaw("Horizontal") * stats.rollSpeed * Time.deltaTime, 0f, Input.GetAxisRaw("Vertical") * stats.rollSpeed * Time.deltaTime);
                targetDirection = Camera.main.transform.TransformDirection(targetDirection);
                targetDirection.y = 0.5f;
                //directional dodgeroll costing 1 Radpoint
                rb.AddForce(targetDirection, ForceMode.Force);
                animator.SetTrigger("DodgeRoll");
                //transform.Translate(targetDirection, Space.World);
                stuntime = 0.8f;
                stamina--;
                playerUsesStamina.Raise();
            }
            
        }
        else
        {
            //quick, short distance backstep costing no Radpoints
        }
    }

    public void Knockback(Vector3 Direction, int force)
    {
        rb.AddForce(Direction* 2, ForceMode.Impulse);
    }

    private void AttackStun(float duration)
    {
        stuntime = duration;
    }

    void RightArmAttack()
    {
        
        if(mut.rArmMutation == 0)
        {
            animator.SetTrigger("RightArmAttackUnmutated");
            AttackStun(0.9f);
        }
        else if (mut.rArmMutation == 1 && IsPlaying(animator, "RightArm_Attack_Defected"))
        {
            animator.SetTrigger("RightArmAttackDefected2");
            AttackStun(0.9f);
        }
        else if(mut.rArmMutation == 1)
        {
            animator.SetTrigger("RightArmAttackDefected");
            AttackStun(1.1f);
        }
    }

    void LeftArmAttack()
    {
        if (mut.lArmMutation == 0)
        {
            animator.SetTrigger("LeftArmAttackUnmutated");
            AttackStun(0.5f);
        }
        else if (mut.lArmMutation == 1)
        {
            animator.SetTrigger("LeftArmAttackDefected");
            AttackStun(0.7f);
        }
    }

    private void RegainStamina()
    {
        if (stamTimer <= 0)
        {
            stamina++;
            stamTimer = 5f;
            playerUsesStamina.Raise();

        }
        else
        {
            stamTimer -= Time.deltaTime;
        }
    }

    public void Respawn(Vector3 location)
    {
        transform.position = location;
        stamina = maxStamina;
        stamTimer = 5f;
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

    public void Becomeinvisible()
    {
        GetComponent<MeshRenderer>().enabled = false;
    }

    public void BecomeVisible()
    {
        GetComponent<MeshRenderer>().enabled = true;
    }
}
