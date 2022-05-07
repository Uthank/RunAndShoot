using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private State _firstState;

    private Player _target;

    public State Current { get; private set; }

    private void Start()
    {
        _target = GetComponent<Enemy>().Target;
        Reset(_firstState);
    }

    private void Update()
    {
        if (Current == null)
            return;

        var nextState = Current.GetNextState();
        if (nextState != null)
            Transit(nextState);
    }

    public void Reset(State startState)
    {
        Current = startState;

        if (Current != null)
            Current.Enter(_target);
    }

    private void Transit(State nextState)
    {
        if (Current != null)
            Current.Exit();

        Current = nextState;

        if (Current != null)
            Current.Enter(_target);
    }
}
