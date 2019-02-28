using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class    Combat : MonoBehaviour
{
    private int maxHealth;
    public int health;

    public int rArmAttackPower;
    public int rLegAttackPower;

    public int defense;

    public void TakeDamage(int damage)
    {
        if(damage - defense <= 0)
        {
            health -= 1;
        }
        else
        {
            health -= damage - defense;
        }
        
        if(health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
        //GameObject ragdoll = (GameObject)Instantiate(aa, transform.position, transform.rotation);
    }
}
