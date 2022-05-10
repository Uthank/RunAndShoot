using UnityEngine;
using UnityEngine.Events;

public class Player : Archer
{
    private Mover _mover;

    public UnityAction Killed;

    public bool IsAlive { get; private set; } = true;

    protected override void Awake()
    {
        Crowd = GetComponent<Crowd>();
        _mover = GetComponent<Mover>();
        base.Awake();
    }

    public void Damage()
    {
        if (Crowd.Damage() == false)
            Kill();
    }

    public override void Kill(Transform forceSource = null, float force = 0)
    {
        Killed?.Invoke();
        IsAlive = false;
        _mover.DisableInput();
        _mover.enabled = false;
        base.Kill(forceSource, force);
    }
}
