using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu]
public class SortEvent : ScriptableObject
{

    private List<SortEventListener> listeners = new List<SortEventListener>();

    public void Raise()
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised();
        }
    }

    public void RegisterListener(SortEventListener listener)
    {
        if(listeners.Contains(listener))
        {
            throw new InvalidOperationException("Duplicate key");
        }
        listeners.Add(listener);
    }

    public void UnregisterListener(SortEventListener listener)
    {
        if (listeners.Contains(listener))
        {
            listeners.Remove(listener);
        }
        else
        {
            throw new InvalidOperationException("No listeners to remove!");
        }
    }
}
