using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testscript : MonoBehaviour
{
    public GameEvent gameEvent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            //Vector3 hitDirection = other.transform.position - transform.position;
            //other.GetComponent<PlayerController>().Knockback(hitDirection, 4);
            //Debug.Log("AAA");
            gameEvent.Raise();

        }
    }
}
