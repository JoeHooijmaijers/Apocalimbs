using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiseEventOnTriggerEnter : MonoBehaviour
{
    public GameEvent triggerEnterEvent;
    public GameEvent triggerExitEvent;

    public bool destroyOnActivate;
    public bool disableOnActivate;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            triggerEnterEvent.Raise();
            if (destroyOnActivate)
            {
                StartCoroutine(DestroyWithTimer());
            }
            else if (disableOnActivate)
            {
                DisableObject();
            }
        }     
    }

    IEnumerator DestroyWithTimer()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(triggerExitEvent != null)
            {
                triggerExitEvent.Raise();
            }
        }
    }

    public void DisableObject()
    {
        gameObject.SetActive(false);
    }

    public void EnableObject()
    {
        gameObject.SetActive(true);
    }
}
