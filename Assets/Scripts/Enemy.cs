using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public enum State
    {
        Appear,
        Disappear,
    }

    State _currentState;
    public State CurrentState => _currentState;

    public void Init()
    {
        _currentState = State.Disappear;
    }

    public void Appear(Action onFinish = null)
    {
        _currentState = State.Appear;
        SetActive(true);
        onFinish?.Invoke();
    }

    public void Disappear(Action onFinish = null)
    {
        SetActive(false);
        _currentState = State.Disappear;
        onFinish?.Invoke();
    }

    public void SetActive(bool value)
    {
        gameObject.SetActive(value);
    }
}
