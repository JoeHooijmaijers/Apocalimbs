using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    [SerializeField] private Transform player;
    public GameEvent InTalkRange;
    public GameEvent OutOfTalkRange;
    public GameEvent StartTalking;
    public GameEvent ContinueTalking;
    public GameEvent StopTalking;
    //public GameEvent StopTalking;

    [SerializeField] private bool playerInRange;
    [SerializeField] private bool talking;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(player.position);

        if (playerInRange == true)
        {
            if (Input.GetKeyDown(KeyCode.T)){
                if(talking != true)
                {
                    talking = true;
                    StartTalking.Raise();
                }
                else
                {
                    ContinueTalking.Raise();
                }
                
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerInRange = true;
            InTalkRange.Raise();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            playerInRange = false;
            OutOfTalkRange.Raise();
            if (talking == true)
            {
                talking = false;
                //StopTalking.Raise();
            }
        }
    }


}
