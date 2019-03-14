using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public int damage;
    private void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Enemy" || col.tag == "Player")
        {
            col.GetComponent<Combat>().TakeDamage(damage);
            Debug.Log(col);
        }
    }
}
