using UnityEngine;

public class Ally : Archer, IKillable
{
    [SerializeField] private Color _aliveColor;
    [SerializeField] private Renderer _renderer;
    [SerializeField] private Color _deathColor;

    private Attacker _attacker;
    private Ragdoll _ragdoll;

    public Player Player { get; private set; }
    public Crowd Crowd { get; private set; }

    private void Awake()
    {
        _ragdoll = GetComponent<Ragdoll>();
        _attacker = GetComponent<Attacker>();
        _renderer.material.color = _aliveColor;
    }

    public void Initialize(Player player)
    {
        Player = player;
        Crowd = player.GetComponent<Crowd>();
    }

    public void Kill()
    {
        transform.parent = null;
        _attacker.DisableInput();
        Crowd.RemoveAlly(this);
        _ragdoll.TurnOnRagdoll();
        _renderer.material.color = _deathColor;
    }
}
