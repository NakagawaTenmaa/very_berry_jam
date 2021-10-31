using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMain : MonoBehaviour
{
    [SerializeField] EnemyManager _enemyManager;

    void Start()
    {
        _enemyManager.Init();

        EventManager.Instance.AddListener((eventType) =>
        {
            if (eventType == EventType.Failure)
            {
                EffectManager.Play(EffectData.EffectType.GameOver);
                Debug.Log("ゲームオーバー");
            }
        });
    }

    void Update()
    {
        
    }
}
