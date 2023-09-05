using UnityEngine;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;
using UnityEngine.Events;

public static class EventController
{
    public delegate void NotParamMethod();
    public static void AddEvent(ref Button button, UnityAction unityAction) => button.onClick.AddListener(unityAction);
    public static void AddEvent(ref EventTrigger trigger, EventTriggerType type, NotParamMethod method)
    {
        EventTrigger.Entry entry = GetEventEntry(type);
        entry.callback.AddListener( e => { method(); });
        trigger.triggers.Add(entry);
    }
    public static EventTrigger.Entry GetEventEntry(EventTriggerType type)
    {
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = type;
        return entry;       
    }
}
