using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Player _target;
    [SerializeField] private Color _aliveColor;
    [SerializeField] private Color _deathColor;
    [SerializeField] private Renderer _renderer;

    private Animator _animator;
    private EnemyStateMachine _enemyStateMachine;
    private List<State> _states = new List<State>();
    private List<Transition> _transitions = new List<Transition>();
    private Ragdoll _ragdoll;

    public Player Target => _target;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _enemyStateMachine = GetComponent<EnemyStateMachine>();
        _states.AddRange(GetComponents<State>());
        _transitions.AddRange(GetComponents<Transition>());
        _ragdoll = GetComponent<Ragdoll>();
        _renderer.material.color = _aliveColor;
    }

    public void SetTarget(Player target)
    {
        _target = target;
    }

    public void Kill()
    {
        _ragdoll.TurnOnRagdoll();
        _enemyStateMachine.enabled = false;

        foreach (var state in _states)
        {
            state.enabled = false;
        }

        foreach (var transition in _transitions)
        {
            transition.enabled = false;
        }

        _renderer.material.color = _deathColor;
    }
}
