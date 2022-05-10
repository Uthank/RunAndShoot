using UnityEngine;

public abstract class Transition : MonoBehaviour
{
    [SerializeField] private State _targetState;

    protected King Target { get; private set; }

    public State TargetState => _targetState;

    public bool NeedTransit { get; set; }

    private void OnEnable()
    {
        NeedTransit = false;
    }

    public void Init(King target)
    {
        Target = target;
    }
}