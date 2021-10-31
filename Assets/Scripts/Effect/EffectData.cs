using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Effect Data")]
public class EffectData : ScriptableObject
{
    public enum EffectType
    {
        GameOver,
    }

    [Serializable]
    public struct EffectInstanceData
    {
        public EffectObject effect;
        public int count;
    }

    [SerializeField] List<EffectInstanceData> _effectList = new List<EffectInstanceData>();
    public List<EffectInstanceData> EffectList => _effectList;

    /// <summary>
    /// エフェクトデータ取得
    /// </summary>
    /// <param name="effectType"></param>
    /// <returns></returns>
    public EffectObject GetEffect(EffectType effectType)
    {
        foreach (var effect in _effectList)
        {
            if (effect.effect.EffectType == effectType)
            {
                return effect.effect;
            }
        }
        return null;
    }
}
