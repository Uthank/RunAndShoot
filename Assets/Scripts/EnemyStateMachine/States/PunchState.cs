using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PunchState : State
{
    private Animator _animator;
    private Enemy _enemy;
    private string _punchAnimation = "Punch";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _enemy = GetComponent<Enemy>();
    }

    private void OnEnable()
    {
        if (Target.IsAlive == true)
        {
            _animator.SetTrigger(_punchAnimation);
        }
    }

    public void Hit()
    {
        if (Target.IsAlive == true)
        {
            Target.Damage();
            _enemy.Damage();
        }
    }
}
