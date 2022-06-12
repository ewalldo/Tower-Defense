using System.Collections.Generic;
using UnityEngine.Events;

public class SimpleEventBus
{
    private static readonly IDictionary<string, UnityEvent> Events = new Dictionary<string, UnityEvent>();

    public static void Subscribe(string eventType, UnityAction listener)
    {
        UnityEvent thisEvent;

        if (Events.TryGetValue(eventType, out thisEvent))
        {
            thisEvent.AddListener(listener);
        }
        else
        {
            thisEvent = new UnityEvent();
            thisEvent.AddListener(listener);
            Events.Add(eventType, thisEvent);
        }
    }

    public static void Unsibscribe(string eventType, UnityAction listener)
    {
        UnityEvent thisEvent;

        if (Events.TryGetValue(eventType, out thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }

    public static void Publish(string eventType)
    {
        UnityEvent thisEvent;

        if (Events.TryGetValue(eventType, out thisEvent))
        {
            thisEvent.Invoke();
        }
    }
}
