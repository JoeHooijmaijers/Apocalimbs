using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slidingDoor : MonoBehaviour
{
    [SerializeField] private Vector3 closedPos;
    [SerializeField] private Vector3 openPos;

    [SerializeField] private float slidingSpeed;

    public void OpenDoor()
    {
        StartCoroutine(IEOpenDoor());
    }

    public void CloseDoor()
    {
        StartCoroutine(IECloseDoor());
    }

    IEnumerator IEOpenDoor()
    {
        while(transform.position != openPos)
        {
            transform.position = transform.position = Vector3.MoveTowards(transform.position, openPos, Time.deltaTime * slidingSpeed);
            yield return null;
        }
    }

    IEnumerator IECloseDoor()
    {
        while (transform.position != closedPos)
        {
            transform.position = transform.position = Vector3.MoveTowards(transform.position, closedPos, Time.deltaTime * slidingSpeed);
            yield return null;
        }
    }

    
}
