using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelebrateState : State
{
    private Animator _animator;
    private string _fallAnimation = "Fall";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _animator.SetTrigger(_fallAnimation);
    }
}
