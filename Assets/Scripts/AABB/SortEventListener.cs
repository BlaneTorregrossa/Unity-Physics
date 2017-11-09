using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class SortEventListener : MonoBehaviour
{
    public SortEvent Event;
    public UnityEvent Response;

    private void OnEnable()
    {
        Event.RegisterListener(this);
        Debug.Log("OnEnable");
    }

    private void OnDisable()
    {
        Event.UnregisterListener(this);
        Debug.Log("OnDisable");
    }

    public void OnEventRaised()
    {
        Response.Invoke();
        Debug.Log("OnEventRaised");
    }
}
