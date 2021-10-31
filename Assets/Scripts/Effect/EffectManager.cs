using System;
using System.Collections.Generic;
using UnityEngine;

public partial class EffectManager : SingletonMonoBehaviour<EffectManager>
{
    [SerializeField] List<EffectObject> _staticEffectList = new List<EffectObject>();
    [SerializeField] EffectData _effectData = null;
    List<EffectObject> _effectList;

    protected override void OnAwake()
    {
        _effectList = new List<EffectObject>();

        GameObject root = new GameObject();
        root.name = "Effect_Root";
        root.transform.position = Vector3.zero;

        foreach (var effect in _staticEffectList)
        {
            effect.Init();
            AddEffect(effect);
        }

        foreach (var effect in _effectData.EffectList)
        {
            for (int i = 0; i < effect.count; i++)
            {
                EffectObject go = Instantiate<EffectObject>(effect.effect, root.transform);
                Debug.Assert(go != null, "EffectObjectが取得できません。");
                _effectList.Add(go);
            }
        }
    }

    protected override void OnDispose()
    {
        if (_effectList != null)
        {
            _effectList.Clear();
        }
    }

    /// <summary>
    /// 初期化
    /// </summary>
    /// <param name="effectData"></param>
    public static void Init(EffectData effectData)
    {
        EffectManager instance = Instance;
        instance._effectData = effectData;
    }

    /// <summary>
    /// エフェクト追加
    /// </summary>
    /// <param name="effect"></param>
    public static void AddEffect(EffectObject effect)
    {
        EffectManager instance = Instance;
        instance._effectList.Add(effect);
    }

    /// <summary>
    /// エフェクト再生
    /// </summary>
    /// <param name="onFinish"></param>
    public static void Play(EffectData.EffectType effectType, Vector3 position, Quaternion rotation, Vector3 scale, Action onFinish = null)
    {
        EffectManager instance = Instance;
        EffectObject effect = instance.GetEffect(effectType);
        Debug.Assert(effect != null, effectType + "は存在しません。");
        effect.transform.localScale = scale;
        effect.transform.rotation = rotation;
        effect.transform.position = position;
        effect.Play(onFinish);
    }

    /// <summary>
    /// エフェクト再生
    /// </summary>
    /// <param name="onFinish"></param>
    public static void Play(EffectData.EffectType effectType, Vector3 position, Quaternion rotation, Action onFinish = null)
    {
        EffectManager instance = Instance;
        EffectObject effect = instance.GetEffect(effectType);
        if (effect == null) return;
        effect.transform.rotation = rotation;
        effect.transform.position = position;
        effect.Play(onFinish);
    }

    /// <summary>
    /// エフェクト再生
    /// </summary>
    /// <param name="onFinish"></param>
    public static void Play(EffectData.EffectType effectType, Vector3 position, Vector3 scale, Action onFinish = null)
    {
        EffectManager instance = Instance;
        EffectObject effect = instance.GetEffect(effectType);
        if (effect == null) return;
        effect.transform.localScale = scale;
        effect.transform.position = position;
        effect.Play(onFinish);
    }

    /// <summary>
    /// エフェクト再生
    /// </summary>
    /// <param name="onFinish"></param>
    public static void Play(EffectData.EffectType effectType, Vector3 position, Action onFinish = null)
    {
        EffectManager instance = Instance;
        EffectObject effect = instance.GetEffect(effectType);
        if (effect == null) return;
        effect.transform.position = position;
        effect.Play(onFinish);
    }

    /// <summary>
    /// エフェクト再生
    /// </summary>
    /// <param name="onFinish"></param>
    public static void Play(EffectData.EffectType effectType, Action onFinish = null)
    {
        EffectManager instance = Instance;
        EffectObject effect = instance.GetEffect(effectType);
        if (effect == null) return;
        effect.Play(onFinish);
    }

    /// <summary>
    /// エフェクトデータ取得
    /// </summary>
    /// <param name="effectType"></param>
    /// <returns></returns>
    EffectObject GetEffect(EffectData.EffectType effectType)
    {
        foreach (var effect in _effectList)
        {
            if (effect.EffectType == effectType)
            {
                if (effect.IsPlaying == false)
                {
                    return effect;
                }
            }
        }
        return null;
    }
}
