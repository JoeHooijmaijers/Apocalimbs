using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector3 targetLoc;
    [SerializeField] private Transform parent;
    [SerializeField] private float projectileSpeed;

    private bool advancing;
    private bool returning;

    // Start is called before the first frame update
    void Awake()
    {
        targetLoc = GameObject.FindGameObjectWithTag("Player").transform.position;
        FlyTowards();
    }

    // Update is called once per frame
    void Update()
    {
        if (advancing == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetLoc, Time.deltaTime * projectileSpeed);
        }
        else if (returning == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, parent.position, Time.deltaTime* projectileSpeed);
        }
    }

    void FlyTowards()
    {
        advancing = true;
        returning = false;
    }

    void Return()
    {
        returning = true;
        advancing = false;
    }
}
