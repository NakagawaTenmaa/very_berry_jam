using System;
using UnityEngine;

public class AnimatorObject : MonoBehaviour
{
    [SerializeField] protected Animator _animator = null;
    protected Action _onFinish;
    protected string _name = "";

    public Action OnFinish { get { return _onFinish; } set { _onFinish = value; } }
    public string Name { get { return _name; } set { _name = value; } }

    void Update()
    {
        Debug.Assert(_animator != null, "アニメーターがNULLです");

        AnimatorClipInfo[] clipInfo = _animator.GetCurrentAnimatorClipInfo(0);
        if (clipInfo == null
        || clipInfo.Length == 0
        || clipInfo[0].clip.name != _name)
        {
            return;
        }

        AnimatorStateInfo currentState = _animator.GetCurrentAnimatorStateInfo(0);
        if (currentState.normalizedTime >= 1)
        {
            _onFinish?.Invoke();
            _onFinish = null;
        }
    }

    public void SetActive(bool state)
    {
        gameObject.SetActive(state);
    }
}
