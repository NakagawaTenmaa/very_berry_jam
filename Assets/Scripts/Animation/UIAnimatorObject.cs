using System;

public class UIAnimatorObject : AnimatorObject
{
    /// <summary>
    /// Inアニメーション
    /// </summary>
    /// <param name="onFinish"></param>
    public void In(Action onFinish = null)
    {
        OnFinish = onFinish;
        Name = "In";
        _animator.SetBool("out", false);
        _animator.SetBool("on", false);
        _animator.SetBool("off", false);
        _animator.SetBool("in", true);
    }

    /// <summary>
    /// Outアニメーション
    /// </summary>
    /// <param name="onFinish"></param>
    public void Out(Action onFinish = null)
    {
        OnFinish = onFinish;
        Name = "Out";
        _animator.SetBool("in", false);
        _animator.SetBool("on", false);
        _animator.SetBool("off", false);
        _animator.SetBool("out", true);
    }

    /// <summary>
    /// 表示
    /// </summary>
    public void On()
    {
        Name = "On";
        _animator.SetBool("in", false);
        _animator.SetBool("out", false);
        _animator.SetBool("off", false);
        _animator.SetBool("on", true);
    }

    /// <summary>
    /// 非表示
    /// </summary>
    public void Off()
    {
        Name = "Off";
        _animator.SetBool("in", false);
        _animator.SetBool("out", false);
        _animator.SetBool("on", false);
        _animator.SetBool("off", true);
    }
}