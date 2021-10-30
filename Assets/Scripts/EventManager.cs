using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : SingletonMonoBehaviour<EventManager>
{
    Action<EventType> _onEvent = null;

    public void AddListener(Action<EventType> onEvent)
    {
        _onEvent += onEvent;
    }

    public void RemoveListener(Action<EventType> onEvent)
    {
        _onEvent -= onEvent;
    }

    public void SetListener(Action<EventType> onEvent)
    {
        _onEvent = onEvent;
    }

    public void RemoveListeners()
    {
        _onEvent = null;
    }

    public void OnEvent(EventType eventType)
    {
        _onEvent?.Invoke(eventType);
    }
}
