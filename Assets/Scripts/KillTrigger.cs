using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillTrigger : MonoBehaviour
{
    public GameEvent gameEvent;
    public TriggerState state;
    
    public GameObject wreckage;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag != "Player")
        {
            col.gameObject.GetComponent<Combat>().Die(player);
            //activatableObj.GetComponent<Door>().OpenDoor();
            state.ClearState();
            gameEvent.Raise();
            GameObject brokentrigger = (GameObject)Instantiate(wreckage, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
