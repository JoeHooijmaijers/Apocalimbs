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
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy")
        {
            Vector3 hitDirection = col.transform.position - par.transform.position;
            col.GetComponent<AIMovement>().Knockback(hitDirection);

            col.GetComponent<Combat>().TakeDamage(damage, par);

        }

        if(col.tag == "Player")
        {
            Vector3 hitDirection = col.transform.position - par.transform.position;
            col.GetComponent<PlayerController>().Knockback(hitDirection);

            col.GetComponent<Combat>().TakeDamage(damage, par);
            Debug.Log(par.GetComponent<Mutation>().rArmPts + " and lv: " + par.GetComponent<Mutation>().rArmMutation);
        }
    }

}
