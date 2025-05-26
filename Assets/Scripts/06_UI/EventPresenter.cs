using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventPresenter : MonoBehaviour
{
    [Serializable]
    public struct Event
    {
        public EventData eventData;
        public UnityEvent onEventTriggered;
    }
    
    [SerializeField] private List<Event> events = new List<Event>();

    private void Start()
    {
        foreach (var eventItem in events)
        {
            if (eventItem.eventData != null)
            {
                eventItem.eventData.onEventInvoked = eventItem.onEventTriggered.Invoke;
            }
        }
    }
}
