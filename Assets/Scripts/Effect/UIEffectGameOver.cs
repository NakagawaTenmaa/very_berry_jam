using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEffectGameOver : EffectObject
{
    [SerializeField] GameObject _bg = null;
    [SerializeField] UIAnimatorObject _animator = null;

    bool _isFinished;

    protected override void OnAwake()
    {
        SetActive(false);
        _animator.SetActive(false);
        _isFinished = false;
    }

    protected override void OnInit()
    {
        
    }

    protected override void OnStart()
    {
        SetActive(true);
        _animator.SetActive(true);
        _animator.In(() =>
        {
            _isFinished = true;
        });
    }

    protected override bool OnUpdate()
    {
        return _isFinished;
    }

    protected override void OnStop()
    {
        
    }
}
