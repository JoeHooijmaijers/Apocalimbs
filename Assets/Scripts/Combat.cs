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

    public Animator anim;

    private void Start()
    {
        mut =  GetComponent<Mutation>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        
    }

    public void TakeDamage(int damage, GameObject damagesource)
    {
        anim.SetTrigger("IsHit");
        if(damage - defense <= 0)
        {
            health -= 1;
        }
        else
        {
            health -= damage - defense;
        }

        Debug.Log(health);

        if(health <= 0)
        {
            Die(damagesource);
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
    }

    public void UpdateDamage()
    {
        if(mut!= null)
        {
            ArmAttackPower *= mut.rArmMutation + 1;
        }
    }

    public void Die(GameObject killer)
    {
        Destroy(gameObject);
        if (killer.tag != "Boss" || killer.tag != "Projectile")
        {
            killer.GetComponent<Mutation>().AbsorbMutations(mut.lArmPts, mut.rArmPts, mut.lLegPts, mut.rLegsPts);
        }
        //GameObject ragdoll = (GameObject)Instantiate(aa, transform.position, transform.rotation);
    }
}
