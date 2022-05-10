using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPunchState : State
{
    private Animator _animator;

    private string _GroundPunchAnimation = "GroundPunch";
    private Boss _boss;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _boss = GetComponent<Boss>();
    }

    private void OnEnable()
    {
        _animator.SetTrigger(_GroundPunchAnimation);
    }

    public void GroundPunch()
    {
        _boss.killAllArchers();
    }
}
