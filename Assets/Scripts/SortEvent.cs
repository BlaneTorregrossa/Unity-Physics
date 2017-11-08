using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// Create a GameEvent in the Project View (EX. GameStart)
/// The GameStart.asset will have it's reference used in the project through the Listener MonoBehaviour
/// </summary>
[CreateAssetMenu]
public class SortEvent : ScriptableObject   // Using Scriptable objects for events
{

    //  List of listeners to this event
    public List<SortEventListener> listeners = new List<SortEventListener>();

    //  raise the event
    // we go backwards to ensure that callers do not cause race conditions
    public void Raise()
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised();
        }
    }

    // subscribe listener to the event, will happen when the listener becomes enabled
    public void RegisterListener(SortEventListener listener)
    {
        if(listeners.Contains(listener))
        {
            throw new InvalidOperationException("Duplicate key. No listeners to be added!");
        }
        
        listeners.Add(listener);
    }

    // remove a listener, will happen when the listener object becomes disabled
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
