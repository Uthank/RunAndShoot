using UnityEngine;
using UnityEngine.Events;

public class Player : Archer, IKillable
{
    [SerializeField] private Color _aliveColor;
    [SerializeField] private Renderer _renderer;
    [SerializeField] private Color _deathColor;

    private Crowd _crowd;
    private Ragdoll _ragdoll;
    private Attacker _attacker;
    private Mover _mover;

    public UnityAction Killed;

    public bool IsAlive { get; private set; } = true;

    private void Awake()
    {
        _crowd = GetComponent<Crowd>();
        _renderer.material.color = _aliveColor;
        _ragdoll = GetComponent<Ragdoll>();
        _attacker = GetComponent<Attacker>();
        _mover = GetComponent<Mover>();
    }

    public void Damage()
    {
        if (_crowd.Damage() == false)
            Kill();
    }

    public void Kill()
    {
        Killed?.Invoke();
        IsAlive = false;
        _mover.DisableInput();
        _mover.enabled = false;
        _attacker.DisableInput();
        _ragdoll.TurnOnRagdoll();
        _renderer.material.color = _deathColor;
    }
}
