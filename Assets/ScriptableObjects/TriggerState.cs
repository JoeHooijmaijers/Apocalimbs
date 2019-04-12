using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Triggerstate", menuName ="LevelProgression/TriggerStates")]
public class TriggerState : ScriptableObject
{
    public bool cleared;

    public void ClearState()
    {
        cleared = true;
    }

    public void UnclearState()
    {
        cleared = false;
    }
}


