using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public enum State
    {
        Appear,
        Disappear,
    }

    [SerializeField] EventCollider _searchCollider;

    State _currentState;
    public State CurrentState => _currentState;

    public void Init()
    {
        _currentState = State.Disappear;

        _searchCollider.SetDelegate((gameObject) =>
        {
            if (!gameObject.CompareTag("Player")) return;
            Debug.Log("å©Ç¬Ç©Ç¡ÇΩÅI");

            EventManager eventManager = EventManager.Instance;
            eventManager.OnEvent(EventType.Failure);
        });
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
