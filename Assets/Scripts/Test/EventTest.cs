using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


/// <summary>
/// Make a gameEvent. (EX. GameStart)
/// </summary>
[CreateAssetMenu]
public class EventTest : ScriptableObject       // Using Scriptable objects for events
{

    // Listeners for the event
    private List<EventTestListener> listeners = new List<EventTestListener>();

    // raise the event
    public void Raise()
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised();
        }
    }

    // subscribe listener to the event
    public void RegisterListener(EventTestListener listener)
    {
        if(listeners.Contains(listener))
        {
            throw new InvalidOperationException("Duplicate key");
        }
        listeners.Add(listener);
    }

    // remove a listener
    public void UnregisterListener(EventTestListener listener)
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
