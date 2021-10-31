using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEffectGameOver : EffectObject
{
    [SerializeField] GameObject _bg = null;
    [SerializeField] GameObject _image = null;

    protected override void OnAwake()
    {
        SetActive(false);
    }

    protected override void OnInit()
    {
        
    }

    protected override void OnStart()
    {
        SetActive(true);
    }

    protected override bool OnUpdate()
    {
        return true;
    }

    protected override void OnStop()
    {
        
    }
}
