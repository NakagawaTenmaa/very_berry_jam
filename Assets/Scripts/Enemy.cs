using System;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public enum State
    {
        Appear,
        Disappear,
    }

    public enum ActiveState
    {
        Idle,
        Walk
    }

    [SerializeField] EventCollider2D _searchCollider;
    [SerializeField] EventCollider2D _mapNodeCollider;

    State _currentState;
    public State CurrentState => _currentState;

    Vector2 _defaultPos;
    ActiveState _currentActiveState;
    List<Vector2Int> _routeList;
    float _moveTime;

    Action _onUpdate;

    public void Init()
    {
        _currentState = State.Disappear;

        _currentActiveState = ActiveState.Idle;
        _routeList = new List<Vector2Int>();
        _defaultPos = transform.position;
        _moveTime = 0;

        _onUpdate = null;

        // 発見イベント
        _searchCollider.onTriggerEnter += (target) =>
        {
            if (!target.CompareTag("Player")) return;
            Debug.Log("見つかった！");

            EventManager eventManager = EventManager.Instance;
            eventManager.OnEvent(EventType.Failure);
        };

        // マップノード探索イベント
        _mapNodeCollider.onTriggerStay += (target) =>
        {
            if (target.CompareTag("MapChip") == false
            ||  _currentActiveState == ActiveState.Walk)
            {
                return;
            }

            _onUpdate = Walk;

            _defaultPos = transform.position;
            _moveTime = 0;

            MapChip node = target.GetComponent<MapChip>();
            if (MapManager.Instance.SearchRouteRandom(0, node.NodeId, _routeList) == true)
            {
                string result = string.Empty;
                for (int i = 0; i < _routeList.Count; i++)
                {
                    Vector2Int route = _routeList[i];
                    result += $"({route.x}, {route.y})";
                    if (i != _routeList.Count - 1)
                    {
                        result += " -> ";
                    }
                }
                Debug.Log(result);
            }

            _currentActiveState = ActiveState.Walk;
            Debug.Log("探索開始");
        };
    }

    void Update()
    {
        _onUpdate?.Invoke();
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

    void Walk()
    {
        if (_routeList.Count != 0)
        {
            _moveTime += Time.deltaTime;
            Vector2Int targetId = _routeList[_routeList.Count - 1];
            Vector2 targetPos = MapManager.Instance.GetNode(0, targetId).WorldPosition;
            transform.position = Vector2.Lerp(_defaultPos, targetPos, _moveTime);
            //float dist = Vector2.Distance(transform.position, targetPos);
            if (_moveTime >= 1)
            {
                _routeList.RemoveAt(_routeList.Count - 1);
                _defaultPos = transform.position;
                _moveTime = 0;
            }
        }
        else
        {
            _onUpdate = null;
            _currentActiveState = ActiveState.Idle;
        }
    }
}
