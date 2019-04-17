using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName ="New GameEvent", menuName = "GameEvents")]
public class GameEvent : ScriptableObject
{
    private List<GameEventListener> GElisteners = new List<GameEventListener>();

    public void Raise()
    {
        for(int i = 0; i <= GElisteners.Count -1; i++)
        {
            GElisteners[i].OnEventRaised();
        }
    }

    public void RegisterListener(GameEventListener listener)
    {
        GElisteners.Add(listener);
    }

    public void UnregisterListener(GameEventListener listener)
    {
        GElisteners.Remove(listener);
    }
}
