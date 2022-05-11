using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(EnemyStateMachine))]
[RequireComponent(typeof(Ragdoll))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Status))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private King _target;
    [SerializeField] private Color _aliveColor;
    [SerializeField] private Color _deathColor;
    [SerializeField] private Renderer _renderer;
    [SerializeField] private Status _status;

    private Ragdoll _ragdoll;
    private Animator _animator;
    private Rigidbody _rigidbody;
    private EnemyStateMachine _enemyStateMachine;

    private List<State> _states = new List<State>();
    private List<Transition> _transitions = new List<Transition>();

    public King Target => _target;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _enemyStateMachine = GetComponent<EnemyStateMachine>();
        _states.AddRange(GetComponents<State>());
        _transitions.AddRange(GetComponents<Transition>());
        _ragdoll = GetComponent<Ragdoll>();
        _status = GetComponent<Status>();
        _renderer.material.color = _aliveColor;
    }

    public void SetTarget(King target)
    {
        _target = target;
    }

    public void ReceiveHitEffect(EffectTypes hitEffect)
    {
        _status.ApplyEffect(hitEffect);
    }

    public virtual void Damage()
    {
        DisableStateMachine();
        _ragdoll.TurnOnRagdoll();
        _renderer.material.color = _deathColor;
    }

    public void DisableStateMachine()
    {
        _enemyStateMachine.enabled = false;

        foreach (var state in _states)
        {
            state.enabled = false;
        }

        foreach (var transition in _transitions)
        {
            transition.enabled = false;
        }
    }
}
