using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillTrigger : MonoBehaviour
{
    public GameObject activatableObj;
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

    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<Combat>().Die(player);
        activatableObj.GetComponent<Door>().OpenDoor();

        GameObject brokentrigger = (GameObject)Instantiate(wreckage, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
