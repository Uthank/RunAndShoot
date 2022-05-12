using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyStateMachine))]
[RequireComponent(typeof(Ragdoll))]
[RequireComponent(typeof(Status))]
public class Enemy : Character
{
    [SerializeField] private Color _aliveColor;
    [SerializeField] private Color _deathColor;
    [SerializeField] private Renderer _renderer;

    private Ragdoll _ragdoll;
    private Status _status;
    private EnemyStateMachine _enemyStateMachine;

    private King _target;
    private EnemySpawner _spawner;
    private List<State> _states = new List<State>();
    private List<Transition> _transitions = new List<Transition>();

    public bool IsAlive { get; private set; } = true;
    public King Target => _target;

    private void Awake()
    {
        _ragdoll = GetComponent<Ragdoll>();
        _states.AddRange(GetComponents<State>());
        _status = GetComponent<Status>();
        _transitions.AddRange(GetComponents<Transition>());
        _enemyStateMachine = GetComponent<EnemyStateMachine>();
        _renderer.material.color = _aliveColor;
    }

    public void Initialize(King target, EnemySpawner enemySpawner)
    {
        _target = target;
        _spawner = enemySpawner;
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
        IsAlive = false;
        _enemyStateMachine.enabled = false;

        if (_spawner != null)
            _spawner.RemoveEnemy(this);

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
