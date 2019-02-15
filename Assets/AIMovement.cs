using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMovement : MonoBehaviour
{
    Transform player;
    NavMeshAgent nav;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        //if()
        //{
        //    nav.SetDestination(player.position);
        //}
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform == player)
        {
            Vector3 LastSeen = new Vector3(player.position.x, player.position.y, player.position.z);
            nav.SetDestination(LastSeen);
        }
    }
}
