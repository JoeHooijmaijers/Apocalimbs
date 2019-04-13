using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    private GameObject par;
    public int damage;

    private void Start()
    {
        par = transform.root.gameObject;
        if(gameObject.tag != "Projectile")
        {
            damage = gameObject.GetComponentInParent<Combat>().ArmAttackPower;
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if(par.tag == "Player")
        {
            if (col.tag == "Enemy")
            {
                Vector3 hitDirection = col.transform.position - par.transform.position;
                int force = GetComponentInParent<Combat>().knockbackforce;
                col.GetComponent<EnemyController>().Knockback(hitDirection, force);

                col.GetComponent<Combat>().TakeDamage(damage, par);

            }

            if (col.tag == "Boss")
            {
                Vector3 hitDirection = col.transform.position - par.transform.position;
                int force = GetComponentInParent<Combat>().knockbackforce;
                col.GetComponent<Boss1Behaviour>().Knockback(hitDirection, force);

                col.GetComponent<Combat>().TakeDamage(damage, par);

            }
        }
        

        if (col.tag == "Player")
        {
            Vector3 hitDirection = col.transform.position - par.transform.position;
            int force = GetComponentInParent<Combat>().knockbackforce;
            col.GetComponent<PlayerController>().Knockback(hitDirection, force);

            col.GetComponent<Combat>().TakeDamage(damage, par);
        }
    }

}
