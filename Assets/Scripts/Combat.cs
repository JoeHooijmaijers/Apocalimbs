using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    [SerializeField]private int maxHealth;
    public int health;

    private Mutation mut;
    public int ArmAttackPower;

    public int knockbackforce;
    public int defense;
    [SerializeField] private float invincibility;
    public Animator anim;

    public GameEvent healthChanged;
    public GameEvent died;

    private void Start()
    {
        mut =  GetComponent<Mutation>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(invincibility > 0)
        {
            invincibility -= Time.deltaTime;
        }
    }

    public void TakeDamage(int damage, GameObject damagesource)
    {
        if(invincibility <= 0)
        {
            anim.SetTrigger("IsHit");
            if (damage - defense <= 0)
            {
                health -= 1;
            }
            else
            {
                health -= damage - defense;
            }

            Debug.Log(health);

            if (health <= 0)
            {
                Die(damagesource);
            }

            if (CheckIfPlayer())
            {
                BecomeInvincible(0.5f);
                healthChanged.Raise();
            }else if (CheckIfBoss())
            {
                healthChanged.Raise();
            }

        }
        
    }

    public void BecomeInvincible(float duration)
    {
        invincibility = duration;
    }

    bool CheckIfPlayer()
    {
        if(gameObject.tag == "Player")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    bool CheckIfBoss()
    {
        if(gameObject.tag == "Boss")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Heal(int healing)
    {
        if(health + healing > maxHealth)
        {
            health = maxHealth;
        }
        else
        {
            health += healing;
        }
        if (CheckIfPlayer())
        {
            healthChanged.Raise();
        }else if (CheckIfBoss())
        {
            healthChanged.Raise();
        }
    }

    public void FullHeal()
    {
        health = maxHealth;
        if (CheckIfPlayer())
        {
            healthChanged.Raise();
        }else if (CheckIfBoss())
        {
            healthChanged.Raise();
        }
    }

    public void UpdateDamage()
    {
        if(mut!= null)
        {
            ArmAttackPower *= mut.rArmMutation + 1;
        }
    }

    public void SelfDestruct()
    {
        Destroy(gameObject);
    }

    public void Die(GameObject killer)
    {
        if (killer.tag != "Boss" || killer.tag != "Projectile")
        {
            if (killer.GetComponent<Mutation>() != null && gameObject.GetComponent<Mutation>() != null)
            {
                killer.GetComponent<Mutation>().AbsorbMutations(mut.lArmPts, mut.rArmPts, mut.lLegPts, mut.rLegsPts);
            }
        }
        if (CheckIfPlayer())
        {
            died.Raise();
        }
        else if (CheckIfBoss())
        {
            died.Raise();
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
}
