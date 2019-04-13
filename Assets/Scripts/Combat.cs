﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    private int maxHealth;
    public int health;

    private Mutation mut;
    public int ArmAttackPower;

    public int knockbackforce;
    public int defense;

    private void Start()
    {
        mut = gameObject.GetComponent<Mutation>();
    }

    public void TakeDamage(int damage, GameObject damagesource)
    {
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

    public void Die(GameObject killer)
    {
        if(killer.tag != "Boss" || killer.tag != "Projectile")
        {
            killer.GetComponent<Mutation>().AbsorbMutations(mut.lArmPts, mut.rArmPts, mut.lLegPts, mut.rLegsPts);
        }
        
        Destroy(gameObject);
        //GameObject ragdoll = (GameObject)Instantiate(aa, transform.position, transform.rotation);
    }
}
