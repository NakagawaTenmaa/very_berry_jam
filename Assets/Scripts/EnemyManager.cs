using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{ 
    [SerializeField] GameObject _enemyPrefab;
    [SerializeField] float _appearSeconds;
    [SerializeField] Vector3 _appearPos;
    Enemy _enemy;

    public Action<Enemy> onAppear;
    public Action<Enemy> onDisappear;

    // テスト用
    float _time;

    void Awake()
    {
        
    }

    public void Init()
    {
        _time = 0;

        GameObject enemyInstance = Instantiate(_enemyPrefab);
        enemyInstance.transform.position = _appearPos;
        _enemy = enemyInstance.GetComponent<Enemy>();
        _enemy.SetActive(false);
        _enemy.Init();
    }

    public void Update()
    {
        // テスト用
        _time += Time.deltaTime;
        if (_time >= _appearSeconds)
        {
            switch (_enemy.CurrentState)
            {
                case Enemy.State.Appear: Disappear(); break;
                case Enemy.State.Disappear: Appear(); break;
                default: break;
            }
            _time = 0;
        }
    }

    void Appear()
    {
        _enemy.Appear(() => onAppear?.Invoke(_enemy));
    }

    void Disappear()
    {
        _enemy.Disappear(() => onDisappear?.Invoke(_enemy));
    }
}
