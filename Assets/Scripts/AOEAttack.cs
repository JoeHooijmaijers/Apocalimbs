using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOEAttack : MonoBehaviour
{
    public int damage;
    [SerializeField] private float duration;
    public int force;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Vector3 hitDirection = other.transform.position - transform.position;
            other.GetComponent<Combat>().TakeDamage(damage, gameObject);
            other.GetComponent<PlayerController>().Knockback(hitDirection, force);
        }
    }

    private void Update()
    {
        if(duration < 0.0f)
        {
            Destroy(gameObject);
        }
        duration -= Time.deltaTime;
    }

    IEnumerator DamageOverTime(Collider other)
    {
        yield return new WaitForSeconds(2.0f);
        other.GetComponent<Combat>().TakeDamage(damage, gameObject);  
    }
}
