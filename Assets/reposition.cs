using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reposition : MonoBehaviour
{
    Transform target;

    private void PosUpdate()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        transform.position = target.position;

        // update the parent position
        transform.parent.position = transform.position;
        // update the box position to zero inside the parent
        transform.localPosition = Vector3.zero;
    }
}
