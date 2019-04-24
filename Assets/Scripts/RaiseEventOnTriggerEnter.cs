using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiseEventOnTriggerEnter : MonoBehaviour
{
    public GameEvent triggerEnterEvent;
    public GameEvent triggerExitEvent;

    public bool destroyOnActivate;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            triggerEnterEvent.Raise();
        }

        if (destroyOnActivate)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            triggerExitEvent.Raise();
        }
    }
}
