using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector3 targetLoc;
    [SerializeField] private Transform parent;
    [SerializeField] private float projectileSpeed;
    public int damage;


    private bool advancing = true;
    private bool returning = false;

    private float distancetoParent;
    private float distancetoTarget;

    // Start is called before the first frame update
    void Awake()
    {
        targetLoc = GameObject.FindGameObjectWithTag("Player").transform.position;
        FlyTowards();
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(targetLoc);
        if (advancing == true)
        {
            distancetoTarget = Vector4.Distance(gameObject.transform.position, targetLoc);
            transform.position = Vector3.MoveTowards(transform.position, targetLoc, Time.deltaTime * projectileSpeed);
            if (distancetoTarget < 0.01f)
            {
                ReturnToParent();
            }
        }
        else if (returning == true)
        {
            distancetoParent = Vector4.Distance(gameObject.transform.position, parent.position);
            transform.position = Vector3.MoveTowards(transform.position, parent.position, Time.deltaTime* projectileSpeed);
            if(distancetoParent < 0.5f)
            {
                Destroy(gameObject);
            }
        }
    }

    public void SetParent(Transform Parent)
    {
        parent = Parent;
    }

    void FlyTowards()
    {
        advancing = true;
        returning = false;
    }

    void ReturnToParent()
    {
        returning = true;
        advancing = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<Combat>().TakeDamage(damage, gameObject);
            ReturnToParent();
        }
    }
}
