using System;
using UnityEngine;

public class EventCollider : MonoBehaviour
{
    Action<GameObject> _onEvent;
    int _eventId;
    EventType _eventType;

    /// <summary>
    /// 初期化
    /// </summary>
    /// <param name="eventId"></param>
    public void Init(EventType eventType, int eventId = 0)
    {
        _eventType = eventType;
        _eventId = eventId;

        
    }

    /// <summary>
    /// イベント発生デリゲート
    /// </summary>
    /// <param name="onEvent"></param>
    public void SetDelegate(Action<GameObject> onEvent)
    {
        _onEvent = onEvent;
    }

    /// <summary>
    /// アクティブ状態設定
    /// </summary>
    /// <param name="state"></param>
    public void SetActive(bool state)
    {
        gameObject.SetActive(state);
    }

    /// <summary>
    /// 表示設定
    /// </summary>
    public void SetEnabled(bool state)
    {
        enabled = state;
    }

    /// <summary>
    /// イベントID取得
    /// </summary>
    /// <returns></returns>
    public int GetEventId()
    {
        return _eventId;
    }

    /// <summary>
    /// イベントタイプ取得
    /// </summary>
    /// <returns></returns>
    public EventType GetEventType()
    {
        return _eventType;
    }

    /// <summary>
    /// 他コライダとの接触判定
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter2D(Collider2D other)
    {
        _onEvent?.Invoke(other.gameObject);
    }

    /// <summary>
    /// 他コリジョンとの接触判定
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionEnter2D(Collision2D collision)
    {
        _onEvent?.Invoke(collision.gameObject);
    }
}
