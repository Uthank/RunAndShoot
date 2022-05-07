using System.Collections;
using UnityEngine;

public class PunchState : State
{
    private Animator _animator;
    private string _punchAnimation = "Punch";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        if (Target != null)
        {
            _animator.SetTrigger(_punchAnimation);
        }
    }

    public void Hit()
    {
        if (Target != null)
        {
            Target.Damage();
            Destroy(gameObject);
        }
    }
}
