using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gremlin : MonoBehaviour
{
    private Transform gremlin;
    private Transform target;
    Vector3 LastSeen;
    private bool triggered;

    private float timeLaunch;
    public float timeAirborne = 1.0f;
    
    private void Update()
    {
        if (triggered)
        {
            //The center of the lunge
            Vector3 center = (gremlin.position + LastSeen) * 0.5F;

            //Arc of the lunge
            center -= new Vector3(0, 1, 0);
            Vector3 relativeCenterGremlin = gremlin.position - center;
            Vector3 relativeCenterTarget = LastSeen - center;

            float lungeFractionComplete = (Time.time - timeLaunch) / timeAirborne;
            transform.position = Vector3.Slerp(relativeCenterGremlin, relativeCenterTarget, lungeFractionComplete);
            transform.position += center;
        }
    }

    private void LungeStart()
    {
        timeLaunch = Time.time;
        //Set transforms
        target = GameObject.FindGameObjectWithTag("Player").transform;
        LastSeen = new Vector3(target.position.x, target.position.y, target.position.z);
        gremlin = this.transform;
        triggered = true;
    }

    private void LungeFinish()
    {
        triggered = false;
    }
}