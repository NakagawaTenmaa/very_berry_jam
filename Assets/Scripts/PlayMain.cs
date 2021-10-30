using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMain : MonoBehaviour
{
    [SerializeField] EnemyManager _enemyManager;

    void Start()
    {
        _enemyManager.Init();
    }

    void Update()
    {

    }
}
