using System;
using UnityEngine;

public class EffectObject : MonoBehaviour
{
    [SerializeField] ParticleSystem _particle = null;

    [SerializeField] EffectData.EffectType _effectType;
    public EffectData.EffectType EffectType => _effectType;

    bool _isPlaying;
    public bool IsPlaying => _isPlaying;

    protected Action _onFinish = null;

    void Awake()
    {
        _isPlaying = false;

        OnAwake();
    }

    void Update()
    {
        UpdateParticle();
        UpdateEffect();
    }

    /// <summary>
    /// 初期化
    /// </summary>
    public void Init()
    {
        OnInit();
    }

    /// <summary>
    /// 初期化
    /// </summary>
    /// <param name="effectType"></param>
    public void Init(EffectData.EffectType effectType)
    {
        _effectType = effectType;
    }

    public void Play(Action onFinish = null)
    {
        PlayParticle(onFinish);
        PlayEffect(onFinish);
    }

    public void Stop()
    {
        StopParticle();
        StopEffect();
    }

    public void SetActive(bool state)
    {
        gameObject.SetActive(state);
    }

    void PlayParticle(Action onFinish)
    {
        if (_particle == null) return;

        if (_particle.isPlaying)
        {
            _particle.Stop();
        }

        _onFinish = onFinish;
        _particle.Play();
        _isPlaying = true;
    }

    void PlayEffect(Action onFinish)
    {
        if (_particle != null) return;

        if (_isPlaying)
        {
            OnStop();
        }

        _onFinish = onFinish;
        OnStart();
        _isPlaying = true;
    }

    void StopParticle()
    {
        if (_particle == null) return;

        _particle.Stop();
        _isPlaying = false;
    }

    void StopEffect()
    {
        if (_particle != null) return;

        OnStop();
        _isPlaying = false;
    }

    void UpdateParticle()
    {
        if (_particle == null) return;
        if (!_isPlaying) return;

        if (!_particle.isPlaying)
        {
            _onFinish?.Invoke();
            _particle.Stop();
            _isPlaying = false;
        }
    }

    void UpdateEffect()
    {
        if (_particle != null) return;
        if (!_isPlaying) return;

        if (!OnUpdate())
        {
            _onFinish?.Invoke();
            OnStop();
            _isPlaying = false;
        }
    }

    #region パーティクル以外のエフェクト再生用
    protected virtual void OnAwake()
    {

    }

    protected virtual void OnInit()
    {

    }

    protected virtual void OnStart()
    {

    }

    protected virtual bool OnUpdate()
    {
        return false;
    }

    protected virtual void OnStop()
    {

    }
    #endregion
}
