using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class EventCollider2D : MonoBehaviour
{
    public Action<GameObject> onTriggerEnter;
    public Action<GameObject> onTriggerStay;
    public Action<GameObject> onTriggerExit;
    public Action<GameObject> onCollisionEnter;
    public Action<GameObject> onCollisionStay;
    public Action<GameObject> onCollisionExit;

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
    /// Trigger接触時
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter2D(Collider2D collision)
    {
        onTriggerEnter?.Invoke(collision.gameObject);
    }

    /// <summary>
    /// Trigger接触中
    /// </summary>
    /// <param name="collision"></param>
    void OnTriggerStay2D(Collider2D collision)
    {
        onTriggerStay?.Invoke(collision.gameObject);
    }

    /// <summary>
    /// Trigger接触停止時
    /// </summary>
    /// <param name="collision"></param>
    void OnTriggerExit2D(Collider2D collision)
    {
        onTriggerExit?.Invoke(collision.gameObject);
    }

    /// <summary>
    /// Collision接触時
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionEnter2D(Collision2D collision)
    {
        onCollisionEnter?.Invoke(collision.gameObject);
    }

    /// <summary>
    /// Collision接触中
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionStay2D(Collision2D collision)
    {
        onCollisionStay?.Invoke(collision.gameObject);
    }

    /// <summary>
    /// Collision接触停止時
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionExit2D(Collision2D collision)
    {
        onCollisionExit?.Invoke(collision.gameObject);
    }
}
